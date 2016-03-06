﻿using System;
using BusinessLogic.Logic.Points;

namespace UI.Models.GameDefinitionModels
{
    public class BoardGameGeekGameDefinitionViewModel
    {
        private const int MaxBggWeight = 5;

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int? MaxPlayers { get; set; }
        public int? MinPlayers { get; set; }
        public int? PlayingTime { get; set; }
        public decimal? AverageWeight { get; set; }
        public string Description { get; set; }

        public Uri BoardGameGeekUri { get; set; }

        public string WeightPercent
        {
            get
            {
                if (AverageWeight.HasValue)
                {
                    
                    return ((AverageWeight.Value * 100) / MaxBggWeight).ToString().Replace(",",".");
                }
                return "0";
            }
        }

        public string WeightDescription { get; set; }

    }
}