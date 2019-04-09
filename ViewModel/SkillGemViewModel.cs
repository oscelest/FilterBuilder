﻿using FilterBuilder.Enum;
using FilterBuilder.Interfaces;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class SkillGemViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Skill Gems";
        public string Image { get; } = "pack://application:,,,/FilterBuilder;component/Resources/Images/SkillGem.png";
        public Enum.View Key { get; } = Enum.View.SKILL_GEM;
    }
}