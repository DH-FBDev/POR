\# Java Project - Realizing High-Level Concepts through Implementation



Chosen Concept: Deciding upon Good and Evil

\## 1. Analysing Mechanisms of "Good and Evil"

To simplify abstract terms like good and evil, align our perception with their function in nature.

\## 1.1 Good in Nature

Good tends to be all actions that benefit the group at no or low cost. Examples include increased offspring survivability and establishing feeding or safety orders that prioritize group protection.

\## 1.2 Evil in Nature

Evil can be defined as all harm or lack of overall benefits. Dysfunctional leaders may protect as much as they harm; parasites masquerading as part of a social order provide no benefits beyond their own survival. Evil is thus when costs outweigh benefits.

\## 1.3 Philosophy as Derivative of Natural Processes

Philosophy, stripped of human exceptionalism and emotional bias, can be defined as the study of costs and benefits within complex social strata. Its goal is to maximize benefits and minimize costs. Philosophical disciplines and frameworks are tools to analyze and refine this base formula.

\## 2. Base Formula: Efficiency as Benefit/Cost Ratio

Define efficiency E as:

E=A/C



where A is Aggregate Benefit and C is Aggregate Cost. If E>1, the cost is justified, and the outcome is considered "Good."



\## 2.1 Signal Cost as a Deontological Warning Sign

The base survival priority formula requires safeguards to prevent justifying harmful costs by appealing to apparent benefits. Such costs often manifest as long-term consequences that gradually erode the original justification or benefit. To address this, we introduce a deontological safeguard: if a signal cost is uncompensated or violates a protected moral value (e.g., "do not kill," "do not steal"), then the cost C is considered infinite.



This means any action violating these safeguarded principles cannot be justified by benefits, no matter how large, effectively rendering the efficiency E=A/C zero or undefined. This enforces strict moral limits within the calculus, ensuring survival priorities are preserved by forbidding actions that violate core ethical constraints.

\## 2.2 Removing Hindsight Bias

Even with deontological safeguards, certain chaotic or unforeseen factors can lead to justifying decisions retrospectively by their outcomes, regardless of intent or rationale. To prevent arbitrary reasoning based on morally charged examples with high positive outcomes, the analysis must focus strictly on ex-ante information.

Functionally, any information that was not available at the time the decision was made cannot be used in the cost-benefit calculation. This restriction prevents outcome-based justification that distorts ethical evaluation.

It is important to note that the process of acquiring information—how and when it becomes available—is a separate issue that requires investigation but lies outside the scope of this decision analysis framework.



\## 2.3 Understanding the Aggregates: Components of Benefit and Cost

In order to apply the formula E=A/C effectively, it is essential to clarify what constitutes the aggregates of benefit A and cost C. These aggregates are not singular, straightforward values but rather the sum of multiple diverse components reflecting the complexity of real-world ethical situations.

\## Components of Aggregate Cost C

Costs can come from various sources, each influencing the overall ethical evaluation differently.

\- Direct tangible costs: For instance, harm inflicted on a victim during a crime, such as physical injury or financial loss.

\- Opportunity costs: Resources or wellbeing lost due to actions taken or not taken.

\- Signal costs: Ethical or moral violations that produce warnings, such as the breach of justice principles.

\- Delayed and indirect costs: Long-term effects like psychological trauma or social distrust that arise from harmful acts.

\- Restorative costs: Efforts needed to repair harm, such as restitution or rehabilitation for victims, which may reduce the net cost.

\## Components of Aggregate Benefit A

Benefits also consist of layered factors, including:

\- Restoration and healing: Reparation efforts that restore victims or communities, increasing overall wellbeing.

\- Social order and safety: Measures that reinforce justice and prevent future harm.

\- Long-term positive outcomes: Such as increased trust or cooperation following ethical conduct.

\- Individual and collective wellbeing: Tangible improvements in lives directly or indirectly affected.

\## Addressing Complexity and Variation

The model must accommodate the fact that not all components will be present or quantifiable in every situation. Some costs and benefits may be subjective or context-dependent, requiring flexibility in weighting and interpretation.

For example, in the case of a crime, calculating cost involves both immediate damage to the victim and the ongoing societal impact. Meanwhile, associated benefits might include successful rehabilitation or deterrence of future crimes.

This layered understanding of aggregates enhances the model's practical relevance and aligns it with measures of justice, focusing on balancing harm and repair as central ethical concerns.

\## 3. The Formula as Code (baseline draft)



public class EthicalAction {

&nbsp;   private double aggregateBenefit; // A

&nbsp;   private Cost aggregateCost;      // C as composed object

&nbsp;   private boolean violatesDeontologicalRule;



&nbsp;   public EthicalAction(double aggregateBenefit, Cost aggregateCost, boolean violatesDeontologicalRule) {

&nbsp;       this.aggregateBenefit = aggregateBenefit;

&nbsp;       this.aggregateCost = aggregateCost;

&nbsp;       this.violatesDeontologicalRule = violatesDeontologicalRule;

&nbsp;       

&nbsp;       if (violatesDeontologicalRule) {

&nbsp;           this.aggregateCost.setInfiniteCost();

&nbsp;       }

&nbsp;   }

&nbsp;   

&nbsp;   // Calculate efficiency E = A / C

&nbsp;   public double calculateEfficiency() {

&nbsp;       double totalCost = aggregateCost.getTotalCost();

&nbsp;       if (totalCost == 0) {

&nbsp;           throw new IllegalArgumentException("Cost cannot be zero");

&nbsp;       }

&nbsp;       if (Double.isInfinite(totalCost)) {

&nbsp;           return 0; // Infinite cost means zero efficiency - action forbidden

&nbsp;       }

&nbsp;       return aggregateBenefit / totalCost;

&nbsp;   }

&nbsp;   

&nbsp;   // Additional methods to get partial cost details, update values, etc.

&nbsp;   }



&nbsp;   class Cost {

&nbsp;   private double operationalCost = 0.0;  // CO

&nbsp;   private double opportunityCost = 0.0;  // OC

&nbsp;   private double signalCost = 0.0;       // S

&nbsp;   private double delayedCost = 0.0;      // D

&nbsp;   private double riskCost = 0.0;         // R



&nbsp;   public Cost() {}



&nbsp;   public void setOperationalCost(double cost) {

&nbsp;       this.operationalCost = cost;

&nbsp;   }

&nbsp;   public void setOpportunityCost(double cost) {

&nbsp;       this.opportunityCost = cost;

&nbsp;   }

&nbsp;   public void setSignalCost(double cost) {

&nbsp;       this.signalCost = cost;

&nbsp;   }

&nbsp;   public void setDelayedCost(double cost) {

&nbsp;       this.delayedCost = cost;

&nbsp;   }

&nbsp;   public void setRiskCost(double cost) {

&nbsp;       this.riskCost = cost;

&nbsp;   }



&nbsp;   public double getTotalCost() {

&nbsp;       return operationalCost + opportunityCost + signalCost + delayedCost + riskCost;

&nbsp;   }



&nbsp;   public void setInfiniteCost() {

&nbsp;       this.operationalCost = Double.POSITIVE\_INFINITY; // effectively infinite total cost

&nbsp;   }

}

