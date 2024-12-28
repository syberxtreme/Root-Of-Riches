using ECommons.Automation;
using ECommons.DalamudServices;
using ECommons.Throttlers;
using ECommons.UIHelpers.AddonMasterImplementations;
using FFXIVClientStructs.FFXIV.Component.GUI;
using Lumina.Excel.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTurnIn.Scheduler.Tasks
{
    internal static class TaskGetIntoInn
    {
        internal static void Enqueue()
        {
            TaskTarget.Enqueue(InnDict[C.InnDataID].InnNPC);
            TaskInteract.Enqueue(InnDict[C.InnDataID].InnNPC);
            P.taskManager.Enqueue(GetInn);
            P.taskManager.Enqueue(PlayerNotBusy);
        }
        internal unsafe static bool GetInn()
        {
            if (Svc.ClientState.TerritoryType == C.InnDataID)
            {
                return true;
            }
            else if (TryGetAddonByName<AtkUnitBase>("Talk", out var Talkaddon) && IsAddonReady(Talkaddon))
            {
                if (FrameThrottler.Throttle("TalkThrottle", 10))
                    new AddonMaster.Talk(Talkaddon).Click();
            }
            else if (TryGetAddonByName<AtkUnitBase>("SelectYesno", out var addon) && IsAddonReady(addon))
            {
                Svc.Log.Debug("SelectYesno Callback");
                if (FrameThrottler.Throttle("SelectYesnoThrottle", 70))
                    Callback.Fire(addon, true, 0);
            }
            else if (TryGetAddonByName<AtkUnitBase>("SelectString", out var SelectStringaddon) && IsAddonReady(SelectStringaddon))
            {
                Svc.Log.Debug("SelectYesno Callback");
                if (FrameThrottler.Throttle("SelectYesnoThrottle", 70))
                    Callback.Fire(SelectStringaddon, true, 0);
            }

            return false;
        }
    }
}