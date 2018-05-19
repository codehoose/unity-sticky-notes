<?php
    include("stickynotes.php");

    $stickyNotes = new StickyNotes();
    if (!$stickyNotes->Open())
    {
        ?>
        <h1>Error!</h1>
        Can't connect to the database. Check settings!
        <?php
        exit();
    }
?>

<html>
    <head>
        <title>Sticky Notes Test Page</title>
        <style type="text/css">
            body, p, div {
                font-family: Arial, Helvetica, Sans Serif;
                font-size: 12pt;
            }

            thead {
                font-weight: bold;
            }

            textarea {
                width: 100%;
                height: 15vw;
            }            
        </style>
    </head>

    <body>

    <h1>Test Page</h1>
    <table width="100%">
        <thead>
        <tr>
            <td>ID</td>
            <td>Scene</td>
            <td>Bug Text</td>
            <td>Location</td>
            <td>Timestamp</td>
        </tr>
        </thead>
        <tbody>
        <?php
            $arr = $stickyNotes->GetStickyNotes("%");
            foreach ($arr as $row)
            { ?>
            <tr>
            <td><?php echo $row["id"]; ?></td>
            <td><?php echo $row["scene"]; ?></td>
            <td><?php echo $row["bugtext"]; ?></td>
            <td>(<?php echo $row["x"]; ?>, <?php echo $row["y"]; ?>, <?php echo $row["z"]; ?>)</td>
            <td><?php echo $row["timestamp"]; ?></td>
            </tr>
              <?php
            }
        ?>
        </tbody>
    </table>
    <hr>
    Add more rows by entering JSON below:
    <form action="insert.php" method="post">
        <textarea name="notes" width="100%"></textarea><br><br>
        <input type="submit" text="Submit">
    </form>
    </body>
</html>

<?php
    $stickyNotes->Close();
?>