using UnityEngine;

public class ProductivtyUnit : Unit
{

    ResourcePile m_CurrentPile = null;
    public float vProdMult = 2;


    protected override void BuildingInRange()
    {
        if(m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {

                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= vProdMult;


            }




        }
    }

    void ResetProduction()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= vProdMult;
            m_CurrentPile = null ;

        }

    }

    public override void GoTo(Building target)
    {
        ResetProduction();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 target)
    {
        ResetProduction();
        base.GoTo(target);
    }

}
