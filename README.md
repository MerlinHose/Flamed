Install Choco:
`@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "[System.Net.ServicePointManager]::SecurityProtocol = 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"`

Get Cloudflared:
`choco install cloudflared`

Start Cloudflared:
`cloudflared access tcp --hostname db.mmerlins.net --url localhost:3307`

# Profil mit der ID Anzeigen (Beispiel)
SELECT t_users.users_displayname, t_profiles.profiles_description, t_profiles.profiles_search, t_images.images_content
FROM t_users
INNER JOIN t_profiles
ON t_users.users_id = t_profiles.profiles_user
INNER JOIN t_images
ON t_users.users_id = t_images.images_users
WHERE t_users.users_id = 1;
