/**
 * Represents an ethical action evaluated by balancing 
 * aggregated benefits against costs with deontological constraints.
 */
public class EthicalAction {
    /** Aggregate benefit value (A) of this action */
    private double aggregateBenefit; 
    
    /** Aggregate cost object representing composed costs (C) */
    private Cost aggregateCost; 
    
    /** Flag indicating whether this action violates a deontological rule */
    private boolean violatesDeontologicalRule;

    /**
     * Constructs an EthicalAction instance.
     * If rule violation is true, sets the aggregate cost to infinite.
     *
     * @param aggregateBenefit the total benefit of the action
     * @param aggregateCost the total associated costs as Cost object
     * @param violatesDeontologicalRule true if action breaches core moral rules
     */
    public EthicalAction(double aggregateBenefit, Cost aggregateCost, boolean violatesDeontologicalRule) {
        this.aggregateBenefit = aggregateBenefit;
        this.aggregateCost = aggregateCost;
        this.violatesDeontologicalRule = violatesDeontologicalRule;

        if (violatesDeontologicalRule) {
            // Assign infinite cost to forbid this action
            this.aggregateCost.setInfiniteCost();
        }
    }

    /**
     * Calculates the efficiency E = A / C.
     * Returns 0 if cost is infinite or throws IllegalArgumentException if cost is zero.
     * 
     * @return efficiency of the action or 0 if forbidden
     * @throws IllegalArgumentException if total cost is zero
     */
    public double calculateEfficiency() {
        double totalCost = aggregateCost.getTotalCost();
        if (totalCost == 0) {
            throw new IllegalArgumentException("Cost cannot be zero");
        }
        if (Double.isInfinite(totalCost)) {
            // Infinite cost means zero efficiency - action forbidden
            return 0;
        }
        return aggregateBenefit / totalCost;
    }

    // Additional getters, setters, or utility methods can be added here
}

/**
 * Encapsulates various components of cost associated 
 * with an ethical action evaluation.
 */
class Cost {
    /** Operational cost component (CO) */
    private double operationalCost = 0.0;

    /** Opportunity cost component (OC) */
    private double opportunityCost = 0.0;

    /** Signal cost component (S) */
    private double signalCost = 0.0;

    /** Delayed cost component (D) */
    private double delayedCost = 0.0;

    /** Risk cost component (R) */
    private double riskCost = 0.0;

    /** Default constructor */
    public Cost() {}

    /** Setters for each cost component */
    public void setOperationalCost(double cost) { this.operationalCost = cost; }
    
    public void setOpportunityCost(double cost) { this.opportunityCost = cost; }

    public void setSignalCost(double cost) { this.signalCost = cost; }

    public void setDelayedCost(double cost) { this.delayedCost = cost; }

    public void setRiskCost(double cost) { this.riskCost = cost; }

    /**
     * Aggregates all cost components into total cost.
     * 
     * @return total sum of all cost components
     */
    public double getTotalCost() {
        return operationalCost + opportunityCost + signalCost + delayedCost + riskCost;
    }

    /**
     * Sets the operational cost to positive infinity 
     * to represent a forbidden or infinitely costly action.
     */
    public void setInfiniteCost() {
        this.operationalCost = Double.POSITIVE_INFINITY;
    }
}