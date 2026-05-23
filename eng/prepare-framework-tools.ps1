$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
$toolsDirectory = Join-Path $repoRoot "tools/lib"
$keysDirectory = Join-Path $repoRoot "tools/keys"
$repository = "https://raw.githubusercontent.com/jni4net/jni4net.github.io/master/mvnrepo"
$dependencyGoal = "org.apache.maven.plugins:maven-dependency-plugin:3.8.1:copy"

New-Item -ItemType Directory -Force -Path $toolsDirectory, $keysDirectory | Out-Null

function Copy-Artifact([string] $artifactId) {
    & mvn --batch-mode --no-transfer-progress $dependencyGoal `
        "-Dartifact=net.sf.jni4net:${artifactId}:0.2.5.0:dll" `
        "-DremoteRepositories=jni4net::default::$repository" `
        "-DoutputDirectory=$toolsDirectory" `
        "-Dmdep.stripVersion=false"
    if ($LASTEXITCODE -ne 0) {
        throw "Maven failed to resolve $artifactId."
    }
}

Copy-Artifact "selvin.exportdll"
Copy-Artifact "selvin.exportdllattribute"

$exporterDll = Join-Path $toolsDirectory "selvin.exportdll-0.2.5.0.dll"
$attributeDll = Join-Path $toolsDirectory "selvin.exportdllattribute-0.2.5.0.dll"
$expectedExporterHash = "A8696EBA3153D5136D32965AD696CEC920DE85AFDCFD7EBB6A19F0BB7F654391"
$expectedAttributeHash = "C89D3E599B9E8ECFC1C24F9A082AFD806019F6A65281B6622AD0401DE11D9235"

if ((Get-FileHash -Algorithm SHA256 $exporterDll).Hash -ne $expectedExporterHash) {
    throw "Unexpected checksum for selvin.exportdll-0.2.5.0.dll."
}
if ((Get-FileHash -Algorithm SHA256 $attributeDll).Hash -ne $expectedAttributeHash) {
    throw "Unexpected checksum for selvin.exportdllattribute-0.2.5.0.dll."
}

Copy-Item -Force $exporterDll (Join-Path $toolsDirectory "selvin.exportdll-0.2.5.0.exe")

$keyPath = Join-Path $keysDirectory "jni4net.snk"
if (!(Test-Path $keyPath)) {
    $sn = Get-ChildItem -Path "${env:ProgramFiles(x86)}\Microsoft SDKs\Windows" -Filter "sn.exe" -Recurse |
        Where-Object { $_.FullName -match "NETFX 4\.8 Tools" } |
        Select-Object -First 1
    if ($null -eq $sn) {
        throw "Could not find the .NET Framework 4.8 strong-name tool (sn.exe)."
    }
    & $sn.FullName -k $keyPath
    if ($LASTEXITCODE -ne 0) {
        throw "Strong-name key generation failed."
    }
}

Write-Host "Prepared verified .NET Framework launcher tools."
