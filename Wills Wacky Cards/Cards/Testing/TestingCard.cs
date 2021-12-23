﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using WWC.Extensions;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using UnityEngine;

namespace WWC.Cards.Testing
{
    class TestingCard : CustomCard
    {
        public void RemoveTestingCards(Player player)
        {
            WillsWackyCards.instance.ExecuteAfterFrames(25, () => {
                List<CardInfo> testCards = new List<CardInfo>();
                foreach (var card in player.data.currentCards)
                {
                    if (card.categories.Contains(WillsWackyCards.TestCardCategory))
                    {
                        testCards.Add(card);
                    }
                }

                ModdingUtils.Utils.Cards.instance.RemoveCardsFromPlayer(player, testCards.ToArray(), ModdingUtils.Utils.Cards.SelectionType.All, true);
            });
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.categories = new CardCategory[] { WillsWackyCards.TestCardCategory };
            UnityEngine.Debug.Log($"[{WillsWackyCards.ModInitials}][Card] {GetTitle()} Built");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {

            UnityEngine.Debug.Log($"[{WillsWackyCards.ModInitials}][Card] {GetTitle()} Added to Player {player.playerID}");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{WillsWackyCards.ModInitials}][Card] {GetTitle()} removed from Player {player.playerID}");
        }

        protected override string GetTitle()
        {
            return "Card Name";
        }
        protected override string GetDescription()
        {
            return "Card Description";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.TechWhite;
        }
        public override string GetModName()
        {
            return WillsWackyCards.TestingInitials;
        }
        public override bool GetEnabled()
        {
            return true;
        }
    }
}
