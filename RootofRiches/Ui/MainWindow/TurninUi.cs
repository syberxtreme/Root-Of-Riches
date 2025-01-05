using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootofRiches.Ui.MainWindow;

internal class TurninUi
{
    public static void Draw()
    {
        ImGui.Text($"Current TurnIn Task → {icurrentTask}");

        string[,] ExchangeTable = new string[,]
        {
            { "Exchangeable Armor", $"{TotalExchangeItem:N0}" }
        };

        string[,] NormalRaidParts = new string[,]
        {
            { "Gordian", "A1-4", $"{GordianTurnInCount:N0}" },
            { "Alexandrian", "A9-12", $"{AlexandrianTurnInCount:N0}" },
            { "Deltascape", "O1-4", $"{DeltascapeTurnInCount:N0}" },
        };

        if (ImGui.BeginTable("RoRAmountofArmorPieces", 2, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
        {
            // Render table rows
            for (int i = 0; i < ExchangeTable.GetLength(0); i++)
            {
                ImGui.TableNextRow();

                for (int col = 0; col < 2; col++)
                {
                    ImGui.TableSetColumnIndex(col);

                    // Calculate the available space and text size
                    var text = ExchangeTable[i, col];
                    var textSize = ImGui.CalcTextSize(text);
                    var columnWidth = ImGui.GetColumnWidth();
                    var cursorPosX = ImGui.GetCursorPosX();

                    // Set the cursor position to center the text
                    ImGui.SetCursorPosX(cursorPosX + (columnWidth - textSize.X) / 2.0f);
                    ImGui.Text(text);
                }
            }

            ImGui.EndTable();
        }
        if (ImGui.BeginTable("ROR NRaid Piece Total", 3, ImGuiTableFlags.Borders | ImGuiTableFlags.RowBg))
        {
            // Set up columns without automatic headers
            ImGui.TableSetupColumn("Raid Series");
            ImGui.TableSetupColumn("Raid Tier");
            ImGui.TableSetupColumn("Total Armor Amount");

            // Custom header row
            ImGui.TableNextRow(ImGuiTableRowFlags.Headers);

            string[] headers = { "Raid Series", "Raid Tier", "Total Armor Amount" };
            for (int col = 0; col < headers.Length; col++)
            {
                ImGui.TableSetColumnIndex(col);

                // Calculate the available space and text size
                var header = headers[col];
                var textSize = ImGui.CalcTextSize(header);
                var columnWidth = ImGui.GetColumnWidth();
                var cursorPosX = ImGui.GetCursorPosX();

                // Set the cursor position to center the text
                ImGui.SetCursorPosX(cursorPosX + (columnWidth - textSize.X) / 2.0f);
                ImGui.Text(header);
            }

            // Render table rows
            for (int i = 0; i < NormalRaidParts.GetLength(0); i++)
            {
                ImGui.TableNextRow();

                for (int col = 0; col < 3; col++)
                {
                    ImGui.TableSetColumnIndex(col);

                    // Calculate the available space and text size
                    var text = NormalRaidParts[i, col];
                    var textSize = ImGui.CalcTextSize(text);
                    var columnWidth = ImGui.GetColumnWidth();
                    var cursorPosX = ImGui.GetCursorPosX();

                    // Set the cursor position to center the text
                    ImGui.SetCursorPosX(cursorPosX + (columnWidth - textSize.X) / 2.0f);
                    ImGui.Text(text);
                }
            }

            ImGui.EndTable();
        }
    }
}
