$Xml = [XML](Get-Content "$PSScriptRoot\src\DisplayConfig\DisplayConfig.csproj")
$Version = $Xml.Project.PropertyGroup.PackageVersion
$DestDirPath = "$PSScriptRoot/build/discon-$Version"
dotnet publish -o $DestDirPath -c:Release -p:DebugType=None

$ArchivePath = "$DestDirPath.zip"

if(Test-Path $ArchivePath){
    Remove-Item $ArchivePath -Force
}

$Children = Get-ChildItem -Path $DestDirPath

foreach($child in $Children){
    Write-Host $child.FullName
    Compress-Archive -Path $child.FullName -DestinationPath $ArchivePath -Update
}