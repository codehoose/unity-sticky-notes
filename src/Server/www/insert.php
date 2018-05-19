<?php
    include("stickynotes.php");

    $stickyNotes = new StickyNotes();

    if (!$stickyNotes->Open())
    {
        echo $stickyNotes->MakeError("Could not open database");
    }
    else
    {
        if (array_key_exists("notes", $_POST))
        {
            if (!trim($_POST["notes"]))
            {
                echo $stickyNotes->MakeError("There are no notes!");
            }
            else
            {
                $notes = json_decode($_POST["notes"], true); // decode to an array with 'true'
                $result = $stickyNotes->InsertOrUpdate($notes["rows"]);
                echo $stickyNotes->MakeError($result);
            }
        }
        else
        {
            echo $stickyNotes->MakeError("Missing data! Post data in field called 'notes'");
        }
    }

    $stickyNotes->Close();
?>