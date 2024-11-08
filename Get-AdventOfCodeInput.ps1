# Define function to download Advent of Code input data

    param (
        [int]$Year,
        [int]$Day
    )
    
    # Retrieve the session cookie from the environment variable
    $sessionCookie = [System.Environment]::GetEnvironmentVariable("AOC_SESSION")
    echo "in = $Year, $Day"
    if (-not $sessionCookie) {
        Write-Output "Error: The AOC_SESSION environment variable is not set. Please set it to your Advent of Code session cookie."
        Write-Output "Ex.  : `$env:AOC_SESSION = `"your_session_cookie_here`""
        Write-Output "https://github.com/GreenLightning/advent-of-code-downloader?tab=readme-ov-file#how-do-i-get-my-session-cookie"
        return
    }

    # Validate the year and day parameters
    if ($Year -lt 2015 -or $Day -lt 1 -or $Day -gt 25) {
        Write-Output "Error: Invalid year or day. Year must be 2015 or later, and day must be between 1 and 25."
        return
    }

    # Construct the URL for the input data
    $url = "https://adventofcode.com/$Year/day/$Day/input"

    # Attempt to download the input data
    try {
        $webClient = New-Object System.Net.WebClient    
        $webClient.Headers.add('Cookie', "session=$sessionCookie")   
        $response = $webClient.DownloadString($url)    
        
        $filePath = "AdventOfCode.Solutions\Inputs\${Year}_{0:D2}_input.txt" -f $Day
        $response | Out-File -FilePath $filePath -Encoding utf8
        Write-Output "Input data for Day $Day of Advent of Code $Year has been saved to '$filePath'."
    } catch {
        Write-Output "Error: Failed to download input data. Please check your session cookie and ensure you have access to the Advent of Code website."
    }


# Example usage:
# Get-AdventOfCodeInput -Year 2023 -Day 1

