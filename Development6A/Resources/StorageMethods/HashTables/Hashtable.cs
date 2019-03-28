using ExtensionMethods;

namespace Development6A.Resources
{
    public class hashtable<K, V>
    {
        // The array stores all the data.
        private KeyValuePair<K, V>[] collection;

        // The amount of entries in the array.
        public int entries { get; private set; }

        // The contructor with initial array size ann initial amount of entries.
        public hashtable()
        {
            collection = new KeyValuePair<K, V>[20];
            this.entries = 0;
        }

        // The contructor where the caller can decide the amount of buckets.
        public hashtable(int AmountofBuckets)
        {
            collection = new KeyValuePair<K, V>[AmountofBuckets];
            this.entries = 0;
        }

        /// <summary>
        /// Make the bucket ammount 2 times larger.
        /// </summary>
        private void ResizeArray()
        {
            // Create the new array with double the amount of space.
            KeyValuePair<K, V>[] newCollection = new KeyValuePair<K, V>[collection.Length * 2];

            // Loop through the old array and place all the value's in the new array.
            for (int i = 0; i < collection.Length; i++)
            {
                // Check to see if the current place in the array has an value
                if (collection[i] != null)
                {
                    // Get the hashcode and make an index for it.
                    int hashCode = collection[i].key.GetHashCode();
                    int index = hashCode % newCollection.Length;

                    // Check if index is an negative number and changes it into an positive number
                    if (index < 0)
                    {
                        index = index * -1;
                    }

                    int arrayindex = index;
                    bool arraycheck = true;
                    while (arraycheck)
                    {
                        // Check if the place in the new array is empty and place the item in the new array and end the loop.
                        if (newCollection[arrayindex] == null)
                        {
                            newCollection[arrayindex] = new KeyValuePair<K, V>()
                                {index = arrayindex, key = collection[i].key, value = collection[i].value};
                            arraycheck = false;
                        }

                        // Change array index depending on the current position of the loop.
                        if (arrayindex >= collection.Length - 1)
                        {
                            arrayindex = 0;
                        }
                        else
                        {
                            arrayindex = arrayindex + 1;
                        }
                    }
                }
            }

            collection = newCollection;
        }

        /// <summary>
        /// Add an item to the hashtable
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void add(K key, V value)
        {
            // Get the hashcode and index of the hashcode.
            this.entries++;
            int hashcode = value.GetHashCode();
            int index = hashcode % collection.Length;

            // Check if index is an negative number and changes it into an positive number
            if (index < 0)
            {
                index = index * -1;
            }

            // Loop through the array to check where the first spot is availeble to add an item.
            int arrayindex = index;
            bool arraycheck = true;
            while (arraycheck)
            {
                // Check if the current arrayindex is empty and adds an item if it is through and stops the loop if it is added.
                if (collection[arrayindex] == null)
                {
                    collection[arrayindex] = new KeyValuePair<K, V>() {index = arrayindex, key = key, value = value};
                    arraycheck = false;
                }

                // Change array index depending on the current position of the loop.
                if (arrayindex >= collection.Length - 1)
                {
                    arrayindex = 0;
                }
                else
                {
                    arrayindex = arrayindex + 1;
                }

            }

            // Controlleert of het aantal volle buckets nooit groter is dan 70% als dat wel zo is wordt de bucket aantal dubbel zoveel.
            if (entries / collection.Length >= 0.7)
            {
                ResizeArray();
            }
        }

        /// <summary>
        /// Remove a value from the hashtable
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Option<KeyValuePair<K, K>></int></returns>
        public Option<KeyValuePair<K, V>> remove(K key)
        {
            // Get the hashcode and index of the hashcode and make temporary key value aan.
            int hashcode = key.GetHashCode();
            int index = hashcode % collection.Length;
            KeyValuePair<K, V> tempValue = new KeyValuePair<K, V>();

            // Check if index is an negative number and changes it into an positive number
            if (index < 0)
            {
                index = index * -1;
            }

            // Loop to check the array for the item that must be removed.
            int arrayindex = index;
            bool arraycheck = true;
            while (arraycheck)
            {
                // Remove the value from the array and decreased the counter for the amount of entries.
                if (collection[arrayindex] != null && collection[arrayindex].key.Equals(key))
                {
                    tempValue = collection[arrayindex];
                    collection[arrayindex] = null;
                    this.entries--;
                    arraycheck = false;
                }

                // Change array index depending on the current position of the loop.
                if (arrayindex >= collection.Length - 1)
                {
                    arrayindex = 0;
                }
                else
                {
                    arrayindex = arrayindex + 1;
                }

                // Check that is doesn't check the starting index twice.
                //  if it failed it return empty other why's it wil return some with the dat in it.
                if (index == arrayindex)
                {
                    return new Empty<KeyValuePair<K, V>>();
                }
            }

            // It succeded and wil return some with the removed value;
            return new Some<KeyValuePair<K, V>>() { data = tempValue };
        }

        public Option<KeyValuePair<K, V>> search(K key)
        {
            // Get the hashcode and index of the hashcode and make temporary key value aan.
            int hashcode = key.GetHashCode();
            int index = hashcode % collection.Length;
            KeyValuePair<K, V> tempValue = new KeyValuePair<K, V>();

            // Check if index is an negative number and changes it into an positive number
            if (index < 0)
            {
                index = index * -1;
            }

            int arrayindex = index;
            bool arraycheck = true;
            while (arraycheck)
            {
                if (collection[arrayindex] != null && collection[arrayindex].key.Equals(key))
                {
                    tempValue = collection[arrayindex];
                    arraycheck = false;
                }

                // Change array index depending on the current position of the loop.
                if (arrayindex >= collection.Length - 1)
                {
                    arrayindex = 0;
                }
                else
                {
                    arrayindex = arrayindex + 1;
                }

                // Check that is doesn't check the starting index twice.
                //  if it failed it return empty other why's it wil return some with the dat in it.
                if (index == arrayindex)
                {
                    return new Empty<KeyValuePair<K, V>>();
                }
            }

            return new Some<KeyValuePair<K, V>>() { data = tempValue };
        }
    }
}