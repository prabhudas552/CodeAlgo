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
                FindPositionOfCycle(slow,fast);
                return true;
            }
            slow = slow.next;
            fast = fast.next.next;
        }
        return false;
    }
    public void FindPositionOfCycle(Node slow,Node fast)
    {
        slow = head;
        while(true)
        {
            if(slow == fast)
            {
                System.Console.WriteLine("Cycle present at : " + slow.data);
                return;
            }
            slow = slow.next;
            fast = fast.next;
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