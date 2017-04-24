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
    public void AddNode(int data)
    {
        Node temp = new Node(data);
        if(head == null)
        {
            head = temp;
            return;
        }
        Node ptr  = head;
        while(ptr.next != null)
            ptr = ptr.next;
        ptr.next = temp;
    }
    public void PrintList()
    {
        Node temp = head;
        while(temp != null)
        {
            System.Console.Write(temp.data +" ");
            temp = temp.next;
        }
        System.Console.WriteLine();
    }
    public void IsPalindrome()
    {
        int length = GetLength();
        if(length == 0 )
            System.Console.WriteLine("Empty string ..!");
        if(length == 1)
            System.Console.WriteLine("List is Palindrome");
        int l = (int)Math.Ceiling((double)length/2);
        length = l;
        if(length % 2 == 0)
        {
            length = l-1;
        }
        Node newhead,temp;
        temp = head;
        int count = 1;
        while(count <= length)
        {
            temp = temp.next;
            count++;
        }
        newhead = temp;
        newhead = ReverseList(newhead);
        Node temp1 = head;
        Node temp2 = newhead;
        if(IsPalindromeUtil(temp1,temp2))
        {
            System.Console.WriteLine("List is Palindrome");
        }else
        {
            System.Console.WriteLine("List is not Palindrome");
        }
        ReverseList(newhead);
    }
    private bool IsPalindromeUtil(Node left,Node right)
    {
        while(right != null)
        {
            System.Console.WriteLine(left.data + " :" + right.data);
            if(left.data != right.data)
                return false;
            left = left.next;
            right = right.next;
        }
        return true;
    }
    private Node ReverseList(Node ptr)
    {
        if(ptr == null)
            return null;
        Node current ,prev,next;
        current = ptr;
        prev = null;
        while(current != null)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        ptr = prev;
        return ptr;
    }
    private int GetLength()
    {
        int l=1;
        if(head == null)
            return 0;
        Node temp = head;
        while(temp != null)
        {
            l++;
            temp = temp.next;
        }
        return l;
    }
    
}
class MainClass
{
    public static void Main(string [] args)
    {
        LinkedList list  = new LinkedList();
        list.AddNode(1);
        list.AddNode(2);
        list.AddNode(3);
        list.AddNode(4);
        list.AddNode(3);
        list.AddNode(2);
        list.AddNode(1);
        //list.AddNode(9);
        list.PrintList();
        list.IsPalindrome();
        list.PrintList();
    }
}