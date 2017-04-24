using System;
class Node
{
    public int data;
    public Node next;
    public Node(int data)
    {
        this.data = data;
        next = null;
    }
}
class LinkedList
{
    Node head;
    public LinkedList(){head = null;}
    
    public void AddNode(int data,bool isLast)
    {
        Node temp = new Node(data);
        if(head==null)
        {
            head = temp;
            return;
        }
        Node ptr = head;
        while(ptr.next != null)
            ptr = ptr.next;
        ptr.next = temp;
        if(isLast)
            ptr.next.next = head.next;
    }
    public void PrintList()
    {
        if(head == null)
        return;
        Node temp = head;
        while(temp !=null )
        {
            System.Console.Write(temp.data +" ");
            temp = temp.next;
        }
    }
    public bool IsCyclicList()
    {
        if(head == null)
            return false;
        Node slow = head;
        Node fast = head;
        while(fast.next !=null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if(slow == fast)
            {
                FindPositionOfCycleMethod1(slow,fast);
                FindPositionOfCycleMethod2(slow);
                FindPositionOfCycleMethod3(slow);
                return true;
            }
            slow = slow.next;
            fast = fast.next.next;
        }
        return false;
    }
    public void FindPositionOfCycleMethod1(Node slow,Node fast)
    {
        slow = head;
        while(true)
        {
            if(slow == fast)
            {
                System.Console.WriteLine("Method1 : Cycle present at :" + slow.data);
                return;
            }
            slow = slow.next;
            fast = fast.next;
        }
    }
    public void FindPositionOfCycleMethod2(Node slow)
    {
        Node temp,temp2;
        temp = head;
        while(true)
        {
            temp2=slow.next;
            while(temp2 != slow)
            {
                if(temp2 == temp)
                {
                    System.Console.WriteLine("Method2 : Cycle Present at :"+temp2.data);
                    return;
                }
                temp2 = temp2.next;
            }
            temp = temp.next;
        }
    }
    public void FindPositionOfCycleMethod3(Node slow)
    {
        int numberOfNodesInLoop = 1;
        Node temp = slow.next;
        while(temp != slow)
        {
            numberOfNodesInLoop++;
            temp = temp.next;
        }
        temp = head;
        while(numberOfNodesInLoop > 0)
        {
            temp = temp.next;
            numberOfNodesInLoop--;
        }
        Node temp2=head;
        while(true)
        {
            if(temp2 == temp)
            {
                System.Console.WriteLine("Method3 : Cycle Present at :"+temp.data);
                return;
            }
            temp2 = temp2.next;
            temp = temp.next;
        }
    }
}
class MainClass
{
    public static void Main(String [] args)
    {
        LinkedList list = new LinkedList();
        list.AddNode(1,false);
        list.AddNode(2,false);
        list.AddNode(3,false);
        list.AddNode(4,false);
        list.AddNode(5,false);
        list.AddNode(6,false);
        list.AddNode(7,false);
        list.AddNode(8,true);
        System.Console.WriteLine("Cycle present :"+list.IsCyclicList());
    }
}