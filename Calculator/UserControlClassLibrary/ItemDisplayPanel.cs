﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlClassLibrary {
    public abstract partial class ItemDisplayPanel<T> : ExpandablePanel {

        protected virtual int VisibleItems { get { return Math.Max(3, TargetHeight / 108); } }
        protected virtual int ItemHeight { get { return TargetHeight / VisibleItems; } }
        protected virtual int ItemMargin { get; set; }

        public virtual int ItemPointer { get; protected set; }
        public virtual T[] Items { get; protected set; }

        public ItemDisplayPanel() {

            InitializeComponent();
            Initialize();
        }

        public ItemDisplayPanel(IHelper helper) : this() {

            Helper = helper;
        }

        protected override void Initialize() {

            base.Initialize();
            ItemMargin = 15;
            Items = new T[0];
            MainPanel.MouseWheel += ScrollPanel;
            OnClear += ClearPanel;
        }

        public void ResetPointer() {

            ItemPointer = 0;
        }

        protected override void ResizeBottomPanel() {

            Helper.SetHeight(BottomPanel, ItemHeight);
            BottomPanel.Width = Width;
            Helper.SetHeight(ClearButton, BottomPanel.Height / 2);
            ClearButton.Width = ClearButton.Height;
            ClearButton.Left = Width - ClearButton.Width - 4;
        }

        public virtual void ClearPanel(object sender, EventArgs e) {

            ItemPointer = 0;
        }

        protected virtual void SetScrollBar() {

            ScrollBar.Visible = CanScroll();

            if(!ScrollBar.Visible) {

                return;
            }

            int height = Height - BottomPanel.Height;
            int padding = height / 10;
            height -= padding;
            double percentage = (double)ItemPointer / (Items.Length - 2);
            ScrollBar.Height = (int)((double)height / Items.Length * (VisibleItems - 1));
            ScrollBar.Top = padding + (int)((height - ScrollBar.Height) * percentage);
            ScrollBar.Left = Parent.Right - ScrollBar.Width * 2 - 1;
        }

        protected virtual bool CanScroll() {

            return ItemPointer > 0 || Items.Length > VisibleItems - 1;
        }

        protected virtual void ScrollUp() {

            if(ItemPointer >= Items.Length - 2) {

                return;
            }

            ItemPointer++;
        }

        protected virtual void ScrollDown() {

            if(ItemPointer <= 0) {

                return;
            }

            ItemPointer--;
        }

        public void ScrollPanel(object sender, MouseEventArgs e) {

            if(!CanScroll()) {

                return;
            }

            if(e.Delta > 0) {

                ScrollDown();

                return;
            }

            ScrollUp();
        }
    }
}