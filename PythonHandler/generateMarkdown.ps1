Push-Location

try {
	doxygen
	Set-Location ./docs

	Get-ChildItem -Recurse -File -Filter *.3 -Path ./man/man3 | ForEach-Object {
		$_.FullName
		pandoc -f man -t markdown -s $_.FullName -o "./md/$(Split-Path -Path $_.FullName -Leaf).md"
	}
}
catch {
	Write-Error $_.Exception.Message
}
finally {
	Pop-Location
}{\rtf1}