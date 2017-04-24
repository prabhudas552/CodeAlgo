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
    Node revhead;
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
    public void PrintList(Node head)
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
        GetReverseList(head);
        if(IsPalindromeUtil(head,revhead))
        {
            System.Console.WriteLine("List is Palindrome");
        }else
        {
            System.Console.WriteLine("List is not Palindrome");
        }
    }
    private bool IsPalindromeUtil(Node head1,Node head2)
    {
        bool isPalindrome = false;
        while(head1 != null && head2 != null)
        {
            if(head1.data != head2.data)
            {
                isPalindrome = false;
                return isPalindrome;
            }
            head1 = head1.next;
            head2 = head2.next;
        }
        isPalindrome = (head1 !=null || head2 != null) ? false : true;
        return isPalindrome;
    }
    private void GetReverseList(Node temp)
    {
       if(temp != null)
       {
            GetReverseList(temp.next);
            if(revhead == null)
            {
                revhead = new Node(temp.data);
            }else
            {
                Node temp1 = new Node(temp.data);
                Node ptr = revhead;
                while(ptr.next != null)
                    ptr = ptr.next;
                ptr.next = temp1;
            }
       }
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
        list.IsPalindrome();
    }
}