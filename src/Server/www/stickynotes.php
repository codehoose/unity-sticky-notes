<?php

    // Class used to access the stickynotes database.
    class StickyNotes
    {
        private $conn = null;

        public function Open()
        {
            date_default_timezone_set('UTC');
            $this->conn = mysqli_connect("localhost", "root", "", "stickynotes");
            return mysqli_connect_errno() == 0;
        }

        public function Close()
        {
            if ($this->conn == null)
                return;

            mysqli_close($this->conn);
        }

        public function GetStickyNotes($sceneName)
        {
            return $this->Get("SELECT * FROM stickynote WHERE `scene` LIKE '$sceneName'");
        }

        public function InsertOrUpdate($rows)
        {
            foreach ($rows as $r)
            {
                $id = $this->Column($r, "id", -1);
                $scene = $this->Column($r, "scene", "");
                $bugtext = $this->Column($r, "bugtext", "");
                $x = $this->Column($r, "x", 0);
                $y = $this->Column($r, "y", 0);
                $z = $this->Column($r, "z", 0);
                $timestamp = $this->Column($r, "timestamp", date(DATE_ATOM));

                $sql = "";

                if ($id > 0)
                    $sql = "UPDATE `stickynote` SET `bugtext`='$bugtext' WHERE `id`=$id;";
                else
                {
                    $sql = "INSERT INTO `stickynote` (`scene`, `bugtext`, `x`, `y`, `z`, `timestamp`) ";
                    $sql .= "VALUES ('$scene', '$bugtext', $x, $y, $z, '$timestamp');";
                }

                mysqli_query($this->conn, $sql);
            }

            return "";
        }

        public function MakeError($errorString)
        {
            $arr = array("error" => $errorString);
            return json_encode($arr);
        }

        public function MakeUnityJson($name, $contents)
        {
            $arr = array($name => $contents);
            return json_encode($arr);
        }

        private function Column($arr, $colName, $default)
        {
            if (array_key_exists($colName, $arr))
                return $arr[$colName];

            return $default;
        }

        private function Get($selectQuery)
        {
            $query = mysqli_query($this->conn, $selectQuery);
            $arr = array();
        
            while ($row = mysqli_fetch_assoc($query))
                $arr[] = $row;
        
            return $arr;
        }
    }
?>