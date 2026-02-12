using UnityEngine;

[CreateAssetMenu(fileName = "NewRule", menuName = "Rules/Rule Definition")]
public class RuleDefinition : ScriptableObject
{
    [TextArea]
    public string ruleDescription;

    public ConditionType conditionType;
    public TriggerTime triggerTime;
    public ConsequenceType consequenceType;
    public SeverityLevel severityLevel;

    [TextArea]
    public string conditionBreakdown;
}
