"..\..\oqtane.framework\oqtane.package\nuget.exe" pack Tres.ReportViewers.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
