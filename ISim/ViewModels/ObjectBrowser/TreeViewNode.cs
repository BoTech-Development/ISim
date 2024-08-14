﻿using ISim.SchematicEditor.Graphic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISim.ViewModels.ObjectBrowser
{
    public class TreeViewNode
    {
        public ObservableCollection<TreeViewNode>? SubNodes { get; set; }
        public String Name { get; set; }
        public String IconSource {  get; set; }
        public  ADrawableComponent Component { get; set; }

        public TreeViewNode(string name, string iconSource, ObservableCollection<TreeViewNode> subNodes)
        {
            SubNodes = subNodes;
            Name = name;
            IconSource = iconSource;
            
        }
        public TreeViewNode(string name, string iconSource, ObservableCollection<TreeViewNode> subNodes, ADrawableComponent component)
        {
            Name = name;
            IconSource = iconSource;
            SubNodes = subNodes;
            Component = component;
        }
    }
}