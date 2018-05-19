<?php
    include("stickynotes.php");

    $sceneName = array_key_exists("scene", $_GET) ? urldecode($_GET["scene"]) : "";
    $stickyNotes = new StickyNotes();

    if (!trim($sceneName))
    {
        echo $stickyNotes->MakeError("Scene name not specified");
    }
    else
    {        
        if (!$stickyNotes->Open())
        {
            echo $stickyNotes->MakeError("Could not open database");
        }
        else
        {
            $arr = $stickyNotes->GetStickyNotes($sceneName);
            echo $stickyNotes->MakeUnityJson("notes", $arr);
        }
    }

    $stickyNotes->Close();
?>