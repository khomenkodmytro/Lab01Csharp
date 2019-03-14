﻿using System;


namespace Lab01Khomenko.Models
{
    public class Storage
    {
        public event Action<Info> InfoChanged;

        public Info Info { get; private set; }

        public void ChangeInfo (Info info)
        {
            Info = info;
            InfoChanged?.Invoke(info);
        }
    }
}
