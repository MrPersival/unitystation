﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UI {
    public class Hands: MonoBehaviour {
        public UI_ItemSlot CurrentSlot { get; private set; } //set primary hand
		public UI_ItemSlot OtherSlot { get; private set; } //set secondary hand
        public bool IsRight { get; private set; }

        public UI_ItemSlot RightSlot;
        public UI_ItemSlot LeftSlot;
        public Transform selector;

        void Start() {
            CurrentSlot = RightSlot;
			OtherSlot = LeftSlot;
            IsRight = true;
        }

        public void Swap() {
            SetHand(!IsRight);
        }

        public void SetHand(bool right) {
            if(right) {
                CurrentSlot = RightSlot;
				OtherSlot = LeftSlot;
            } else {
                CurrentSlot = LeftSlot;
				OtherSlot = RightSlot;
            }

            IsRight = right;
            selector.position = CurrentSlot.transform.position;
        }

        public void SwapItem(UI_ItemSlot itemSlot) {
            if(CurrentSlot != itemSlot) {
                if(!CurrentSlot.IsFull) {
                    Swap(CurrentSlot, itemSlot);
                } else {
                    Swap(itemSlot, CurrentSlot);
                }
            }
        }

        private void Swap(UI_ItemSlot slot1, UI_ItemSlot slot2) {
            if(slot1.TrySetItem(slot2.Item)) {
                slot2.Clear();
            }
        }
    }
}