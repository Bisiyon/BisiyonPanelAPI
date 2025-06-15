using Castle.DynamicLinqQueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BisiyonPanelAPI.CommonObjects
{
    public static class QueryFilterRuleExtensions
    {
        public static void ClearRule(this QueryBuilderFilterRule rules)
        {
            List<QueryBuilderFilterRule> cleanRules = new List<QueryBuilderFilterRule>();
            try
            {
                if (rules != null && rules.Rules != null && rules.Rules.Any())
                {
                    foreach (var rule in rules.Rules)
                    {
                        if (rule.Rules != null && rule.Rules.Count > 0)
                        {
                            rule.ClearRule();
                            continue;
                        }
                        if (rule.Operator == "is_null" || rule.Operator == "is_not_null") continue;
                        if (rule.Value == null)
                        {
                            cleanRules.Add(rule);
                            continue;
                        }
                        if (rule.Value != null && rule.Value.Length == 0)
                        {
                            cleanRules.Add(rule);
                            continue;
                        }
                        if (rule.Value != null && rule.Value.Length > 0 && rule.Value.Any(y => y == null))
                        {
                            cleanRules.Add(rule);
                            continue;
                        }
                    }
                    if (cleanRules.Any())
                    {
                        rules.Rules.RemoveAll(x => cleanRules.Any(y => y.Field == x.Field));
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void ReplaceOperatorRule(this QueryBuilderFilterRule rules)
        {
            try
            {
                if (rules != null && rules.Rules != null && rules.Rules.Any())
                {
                    foreach (var rule in rules.Rules)
                    {
                        if (rule.Rules != null && rule.Rules.Count > 0)
                        {
                            rule.ReplaceOperatorRule();
                            continue;
                        }
                        switch (rule.Operator)
                        {
                            case "notequal":
                                rule.Operator = "not_equal";
                                break;
                            case "startswith":
                                rule.Operator = "begins_with";
                                break;
                            case "endswith":
                                rule.Operator = "ends_with";
                                break;
                            case "notin":
                                rule.Operator = "not_in";
                                break;
                            case "isnull":
                                rule.Operator = "is_null";
                                break;
                            case "isnotnull":
                                rule.Operator = "is_not_null";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void ClearCustomFieldsRule<T>(this QueryBuilderFilterRule filterRule)
        {
            if (filterRule is null || filterRule.Rules is null) return;
            Type type = typeof(T);
            List<PropertyInfo> typeProperties = type.GetProperties().ToList();
            try
            {
                foreach (var rule in filterRule.Rules)
                {
                    if (rule.Rules != null && rule.Rules.Any())
                    {
                        rule.ClearCustomFieldsRule<T>();
                    }
                    else
                    {
                        if (typeProperties.Any(x => x.Name == rule.Field))
                        {
                            continue;
                        }
                        else
                        {

                        }
                    }
                }
                try
                {
                    filterRule.Rules.RemoveAll(x => x.Field is not null && !typeProperties.Any(y => y.Name == x.Field) && !x.Field.Contains("."));
                    filterRule.Rules.RemoveAll(x => x.Field is null && (x.Rules is null || !x.Rules.Any()));
                }
                catch (System.Exception e)
                {

                }
            }
            catch (System.Exception e)
            {

            }
        }
    }
}
