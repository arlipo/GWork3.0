using Microsoft.EntityFrameworkCore;
using Open.Data.Rule;
namespace Open.Infra.Rule
{
    public class RulesDbContext : BaseDbContext<RulesDbContext>
    {
        public RulesDbContext(DbContextOptions<RulesDbContext> o) : base(o) { }
        public DbSet<RuleSetData> RuleSets { get; set; }
        public DbSet<RuleOverrideData> RuleOverrides { get; set; }
        public DbSet<RuleData> Rules { get; set; }
        public DbSet<RuleContextData> RuleContexts { get; set; }
        public DbSet<RuleElementData> RuleElements { get; set; }
        public DbSet<RuleUsageData> RuleUsages { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            InitDatabaseTables(b);
        }

        public static void InitDatabaseTables(ModelBuilder b)
        {
            b.Entity<RuleSetData>().ToTable("RuleSets");
            createRulesTable(b);
            createRulesUsagesTable(b);
            createRuleOverridesTable(b);
            createRuleContextTable(b);
            createRuleElementsTable(b);
        }
        private static void createRuleOverridesTable(ModelBuilder b)
        {
            const string table = "RuleOverrides";
            b.Entity<RuleOverrideData>().ToTable(table);
            createForeignKey<RuleOverrideData, RuleSetData>(b, table, x => x.RuleSetId, x => x.RuleSet);
            createForeignKey<RuleOverrideData, RuleContextData>(b, table, x => x.RuleContextId, x => x.RuleContext);
        }

        private static void createRulesTable(ModelBuilder b)
        {
            const string table = "Rules";
            b.Entity<RuleData>().ToTable(table);
            b.Entity<ActiveRuleData>().ToTable(table);
            createForeignKey<ActiveRuleData, RuleData>(b, table, x => x.RuleID, x => x.Rule);
        }

        private static void createRuleContextTable(ModelBuilder b)
        {
            const string table = "RuleContexts";
            createForeignKey<RuleContextData, RuleSetData>(b, table, x => x.RuleSetID, x => x.RuleSet);
            createForeignKey<RuleContextData, RuleData>(b, table, x => x.RuleID, x => x.Rule);
        }
        internal static void createRulesUsagesTable(ModelBuilder b)
        {
            const string table = "RuleUsages";
            createPrimaryKey<RuleUsageData>(b, table, a => new { a.RuleId, a.RuleSetId });
            createForeignKey<RuleUsageData, RuleData>(b, table, x => x.RuleId, x => x.Rule);
            createForeignKey<RuleUsageData, RuleSetData>(b, table, x => x.RuleSetId, x => x.RuleSet);
        }
        private static void createRuleElementsTable(ModelBuilder b)
        {
            const string table = "RuleElements";
            b.Entity<RuleElementData>().ToTable(table);
            b.Entity<OperatorData>().ToTable(table);
            b.Entity<OperandData>().ToTable(table);
            b.Entity<BaseVariableData>().ToTable(table);
            b.Entity<VariableData<string>>().ToTable(table);
            b.Entity<StringVariableData>().ToTable(table);
            b.Entity<BooleanVariableData>().ToTable(table);
            b.Entity<DateTimeVariableData>().ToTable(table);
            b.Entity<DecimalVariableData>().ToTable(table);
            b.Entity<DoubleVariableData>().ToTable(table);
            b.Entity<IntegerVariableData>().ToTable(table);
            b.Entity<RuleErrorData>().ToTable(table);
            createPrimaryKey<RuleElementData>(b, table, a => new { a.RuleID, a.Name, a.ValidFrom });
            createForeignKey<RuleElementData, RuleData>(b, table, x => x.RuleID, x => x.Rule);
            createForeignKey<BaseVariableData, RuleContextData>(b, table, x => x.RuleContextID, x => x.RuleContext, true);
        }

    }
}

















