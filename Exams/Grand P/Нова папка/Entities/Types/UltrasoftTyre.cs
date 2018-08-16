using System;

public class UltrasoftTyre : Tyre
{
    private double grip;
    private double degradation;

    public UltrasoftTyre(double hardness, double grip) 
        : base(hardness)
    {
        this.Grip = grip;
    }

    public override string Name => "UltrasoftTyre";

    public double Grip
    {
        get { return grip; }
        private set { grip = value;}
    }

    public override double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        var sum = this.Hardness + this.Grip;
        this.Degradation -= sum;
    }
}

