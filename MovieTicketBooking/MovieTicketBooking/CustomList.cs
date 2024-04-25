using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace MovieTicketBooking
{
    public partial class CustomList<Type>
    {
        private int _count;
        private int _capacity;
        
        public int Count { get{return _count;}}
        public int Capacity { get{return _capacity;}}
        private Type [] _array;
        
        public Type this[int index]{
            get{return _array[index];}
            set{_array[index] = value;}

        }

        public CustomList(){
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }  

        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        } 


        public void Add(Type element)
        {
            if(_count==_capacity){
                GrowSize();
            }

             //_array[_count]=element;
             //_count++;
             _count++;
             Insert(0,element);
            

            
        }  


        public void GrowSize()
        {
            _capacity = _capacity*2;
            Type [] temp = new Type[_capacity];

            for(int i =0; i<_count;i++){
                temp[i]=_array[i];
            }

            _array=temp;
        } 


        public void Insert(int Position,Type element)
        {

            Type[] temp = new Type[_capacity];
           for(int i =0; i<_count;i++)
           {
                if(i<position)
                {
                  temp[i]=_array[i];
                }
                else if(i==position){
                    temp[i]=element;
                }

                else{
                    temp[i]=_array[i-1];
                }
           }
           
           _array=temp;
        }

    }
}
