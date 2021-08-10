using KanjiStudy.Core.Models;
using KanjiStudy.Web.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KanjiStudy.Web.Pages
{
    public partial class Stats
    {
        [Inject]
        public virtual LocalStore LocalStore { get; set; }
        private StudyStats[] _stats;
        public StudyStats _selectedStats;

        protected override async Task OnInitializedAsync()
        {
            _stats = await LocalStore.GetStatsAsync();
            _selectedStats = _stats.FirstOrDefault();
        }
    }
}