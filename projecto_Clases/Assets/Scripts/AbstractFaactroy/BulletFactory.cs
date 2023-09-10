using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : AbstractFactory
{
    public BulletFactory(IProduct productToProduce): base(productToProduce) { 
    }
    public override IProduct CreateProduct()
    {
        return product.Clone();
    }
}
