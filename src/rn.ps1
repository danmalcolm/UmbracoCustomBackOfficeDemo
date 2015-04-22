cls

$old_namespace = "UmbracoCodeGenDemo"
$new_namespace = "UmbracoCustomBackOfficeDemo"
$solution_folder = "C:\Users\Dan\Documents\GitHub\UmbracoCustomBackOfficeDemo\src"


# 1. Remove bin / obj folders
get-childItem $solution_folder -include bin,obj -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse }

# 2. Rename folders and files
function rename-items($folder)
{
    foreach ($item in get-childitem $folder)
    {   
        $item_name = $item.FullName
        if($item.FullName.Contains($old_namespace))
        {
            $new_name = $item.FullName.Replace($old_namespace, $new_namespace)
            write-host "Renaming $item"
            write-host "Renaming to $new_name" 
            #            rename-item $item_name $new_name    
            $cmd = 'svn mv "' + $item_name + '" "' + $new_name + '"'
            iex $cmd
            exit
            $item_name = $new_name
            
        }        
        if($item.PSIsContainer)
        {
            rename-items $item_name   
        }
    }    
}
rename-items $solution_folder

# 3. Replace content in all source files (this will also update any paths in solution and project files in line with step 2) 
$src_files = get-childitem $solution_folder -recurse -include *.config,*.cs,*.cshtml,*.csproj,*.sln,*.targets | where { !$_.PSIsContainer }
foreach ($src_file in $src_files)
{    
    write-host "Replacing content in file: $src_file" 
    (Get-Content $src_file.FullName) | % { $_ -replace $old_namespace, $new_namespace } | Set-Content -path $src_file.FullName
}

