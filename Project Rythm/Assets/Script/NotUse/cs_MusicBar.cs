using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class cs_MusicBar
{
    private int                             NodeCount = 0;
    private List<cs_Node>                   list_node = new List<cs_Node>();



    //---------- ---------- ---------- ---------- ----------

    public void CreateBar()
    {
        cs_Node node1 = new cs_Node();
        node1.CreateNode(0, 1, 1);

        //list_node.Insert(++NodeCount, node1);


        cs_Node node2 = new cs_Node();
        node2.CreateNode(0, 2, 2);

        //list_node.Insert(++NodeCount, node2);


        cs_Node node3 = new cs_Node();
        node3.CreateNode(0, 3, 3);

        //list_node.Insert(++NodeCount, node3);
    }
}
