using MyLeoRetailerInfo;
using MyLeoRetailerInfo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLeoRetailer.Common
{
	public class MessageStore
	{
		public static FixedSizeGenericHashTable<string, FriendlyMessage> hash = new FixedSizeGenericHashTable<string, FriendlyMessage>(400);

		static MessageStore()
		{
			#region System

			FriendlyMessage SYS01 = new FriendlyMessage("SYS01", MessageType.Error, "We are currently unable to process your request, Please try again later or contact system administrator.");
			hash.Add("SYS01", SYS01);

			FriendlyMessage SYS02 = new FriendlyMessage("SYS02", MessageType.Information, "Your session has expired. Please login again.");
			hash.Add("SYS02", SYS02);

			FriendlyMessage SYS03 = new FriendlyMessage("SYS03", MessageType.Error, "Please login with valid Username & Password to view this page.");
			hash.Add("SYS03", SYS03);

			FriendlyMessage SYS04 = new FriendlyMessage("SYS04", MessageType.Information, "No records found.");
			hash.Add("SYS04", SYS04);

			FriendlyMessage SYS05 = new FriendlyMessage("SYS05", MessageType.Information, "Password has been changed successfully.");
			hash.Add("SYS05", SYS05);

			FriendlyMessage SYS06 = new FriendlyMessage("SYS06", MessageType.Error, "You dont have online access. Please contact administrator.");
			hash.Add("SYS06", SYS06);

			FriendlyMessage SYS07 = new FriendlyMessage("SYS07", MessageType.Error, "File not found, Please contact administrator.");
			hash.Add("SYS07", SYS07);

			FriendlyMessage SYS08 = new FriendlyMessage("SYS08", MessageType.Error, "Entered User is not an Valid Active directory Member");
			hash.Add("SYS08", SYS08);

			#endregion

			#region Category

			FriendlyMessage CAT01 = new FriendlyMessage("CAT01", MessageType.Success, "Category added successfully.");
			hash.Add("CAT01", CAT01);

			FriendlyMessage CAT02 = new FriendlyMessage("CAT02", MessageType.Success, "Category updated successfully.");
			hash.Add("CAT02", CAT02);

			FriendlyMessage CAT03 = new FriendlyMessage("CAT03", MessageType.Information, "No records found.");
			hash.Add("CAT03", CAT03);

			#endregion

			#region Sub Category

			FriendlyMessage SCAT01 = new FriendlyMessage("SCAT01", MessageType.Success, "Sub category added successfully.");
			hash.Add("SCAT01", SCAT01);

			FriendlyMessage SCAT02 = new FriendlyMessage("SCAT02", MessageType.Success, "Sub category updated successfully.");
			hash.Add("SCAT02", SCAT02);

			FriendlyMessage SCAT03 = new FriendlyMessage("SCAT03", MessageType.Information, "No records found.");
			hash.Add("SCAT03", SCAT03);


			#endregion

            #region Tax

            FriendlyMessage TCAT01 = new FriendlyMessage("TCAT01", MessageType.Success, "Tax added successfully.");
            hash.Add("TCAT01", TCAT01);

            FriendlyMessage TCAT02 = new FriendlyMessage("TCAT02", MessageType.Success, "Tax updated successfully.");
            hash.Add("TCAT02", TCAT02);

            FriendlyMessage TCAT03 = new FriendlyMessage("TCAT03", MessageType.Information, "No records found.");
            hash.Add("TCAT03", TCAT03);

            #endregion

            #region Vendor Contact

            FriendlyMessage VCAT01 = new FriendlyMessage("VCAT01", MessageType.Success, "Vendor Contact added successfully.");
            hash.Add("VCAT01", VCAT01);

            FriendlyMessage VCAT02 = new FriendlyMessage("VCAT02", MessageType.Success, "Vendor Contact updated successfully.");
            hash.Add("VCAT02", VCAT02);

            FriendlyMessage VCAT03 = new FriendlyMessage("VCAT03", MessageType.Information, "No records found.");
            hash.Add("VCAT03", VCAT03);


            #endregion

            #region Color

            FriendlyMessage COL1 = new FriendlyMessage("COL1", MessageType.Success, "Colour Added successfully.");
            hash.Add("COL1", COL1);

            FriendlyMessage COL2 = new FriendlyMessage("COL2", MessageType.Success, "Colour Updated successfully.");
            hash.Add("COL2", COL2);

            #endregion



            #region SizeGroup

            FriendlyMessage SG01 = new FriendlyMessage("SG01", MessageType.Success, "Size Group Added successfully.");
            hash.Add("SG01", SG01);

            FriendlyMessage SG02 = new FriendlyMessage("SG02", MessageType.Success, "Size Group Updated successfully.");
            hash.Add("SG02", SG02);

            #endregion


            #region Vendor

            FriendlyMessage V01 = new FriendlyMessage("V01", MessageType.Success, "Vendor Added successfully.");
            hash.Add("V01", V01);

            FriendlyMessage V02 = new FriendlyMessage("V02", MessageType.Success, "Vendor Updated successfully.");
            hash.Add("V02", V02);

            #endregion


            #region Employee
            FriendlyMessage EMP01 = new FriendlyMessage("EMP01", MessageType.Success, "Employee added successfully.");
            hash.Add("EMP01", EMP01);

            FriendlyMessage EMP02 = new FriendlyMessage("EMP02", MessageType.Success, "Employee Updated successfully.");
            hash.Add("EMP02", EMP02);
            #endregion

            #region Customer

            FriendlyMessage CUST01 = new FriendlyMessage("CUST01", MessageType.Success, "Customer added successfully.");
            hash.Add("CUST01", CUST01);

            FriendlyMessage CUST02 = new FriendlyMessage("CUST02", MessageType.Success, "Customer updated successfully.");
            hash.Add("CUST02", CUST02);

            FriendlyMessage CUST03 = new FriendlyMessage("CUST03", MessageType.Information, "No records found.");
            hash.Add("CUST03", CUST03);

            #endregion

            #region Branch

            FriendlyMessage BRNCH01 = new FriendlyMessage("BRNCH01", MessageType.Success, "Branch added successfully.");
            hash.Add("BRNCH01", BRNCH01);

            FriendlyMessage BRNCH02 = new FriendlyMessage("BRNCH02", MessageType.Success, "Branch updated successfully.");
            hash.Add("BRNCH02", BRNCH02);

            FriendlyMessage BRNCH03 = new FriendlyMessage("BRNCH03", MessageType.Information, "No records found.");
            hash.Add("BRNCH03", BRNCH03);


            #endregion

            #region Gift Voucher

            FriendlyMessage GVAT01 = new FriendlyMessage("GVAT01", MessageType.Success, "Gift Voucher added successfully.");
            hash.Add("GVAT01", GVAT01);

            FriendlyMessage GVAT02 = new FriendlyMessage("GVAT02", MessageType.Success, "Gift Voucher updated successfully.");
            hash.Add("GVAT02", GVAT02);

            FriendlyMessage GVAT03 = new FriendlyMessage("GVAT03", MessageType.Information, "No records found.");
            hash.Add("GVAT03", GVAT03);


            #endregion

            #region Alteration

            FriendlyMessage ALT01 = new FriendlyMessage("ALT01", MessageType.Success, "Alteration added successfully.");
            hash.Add("ALT01", ALT01);

            FriendlyMessage ALT02 = new FriendlyMessage("ALT02", MessageType.Success, "Alteration updated successfully.");
            hash.Add("ALT02", ALT02);

            FriendlyMessage ALT03 = new FriendlyMessage("ALT03", MessageType.Information, "No records found.");
            hash.Add("ALT03", ALT03);


            #endregion

            #region Size

            FriendlyMessage SIZE1 = new FriendlyMessage("SIZE1", MessageType.Success, "Size added successfully.");
            hash.Add("SIZE1", SIZE1);

            FriendlyMessage SIZE2 = new FriendlyMessage("SIZE2", MessageType.Success, "Size updated successfully.");
            hash.Add("SIZE2", SIZE2);

            FriendlyMessage SIZE3 = new FriendlyMessage("SIZE3", MessageType.Information, "No records found.");
            hash.Add("SIZE3", SIZE3);

            FriendlyMessage SIZEG1 = new FriendlyMessage("SIZEG1", MessageType.Success, "Size Group added successfully.");
            hash.Add("SIZEG1", SIZEG1);

            FriendlyMessage SIZEG2 = new FriendlyMessage("SIZEG2", MessageType.Success, "Size Group updated successfully.");
            hash.Add("SIZEG2", SIZEG2);

            FriendlyMessage SIZEG3 = new FriendlyMessage("SIZEG3", MessageType.Information, "No records found.");
            hash.Add("SIZEG3", SIZEG3);


            #endregion

            #region Sales Invoice

            FriendlyMessage SI01 = new FriendlyMessage("SI01", MessageType.Success, "Sales Invoice Added successfully.");
            hash.Add("SI01", SI01);    

            #endregion


            #region Sales Return

            FriendlyMessage SR01 = new FriendlyMessage("SR01", MessageType.Success, "Sales Return Added successfully.");
            hash.Add("SR01", SR01);

            #endregion

		}

		public static FriendlyMessage Get(string code)
		{
			FriendlyMessage message = hash.Find(code);

			return message;
		}

		/// <summary>
		/// struct to hold generic key and value
		/// </summary>
		/// <typeparam name="K">Key</typeparam>
		/// <typeparam name="V">Value</typeparam>
		/// <remarks></remarks>
		public struct KeyValue<K, V>
		{
			/// <summary>
			/// Gets or sets the key.
			/// </summary>
			/// <value>The key.</value>
			/// <remarks></remarks>
			public K Key
			{
				get;
				set;
			}
			/// <summary>
			/// Gets or sets the value.
			/// </summary>
			/// <value>The value.</value>
			/// <remarks></remarks>
			public V Value
			{
				get;
				set;
			}
		}

		/// <summary>
		/// FixedSizeGenericHashTable
		/// </summary>
		/// <typeparam name="K">Key</typeparam>
		/// <typeparam name="V">Value</typeparam>
		/// <remarks>Object for FixedSizeGenericHashTable of key K and of value V</remarks>
		public class FixedSizeGenericHashTable<K, V>
		{
			private readonly int size;
			private readonly LinkedList<KeyValue<K, V>>[] items;

			public FixedSizeGenericHashTable(int size)
			{
				this.size = size;
				items = new LinkedList<KeyValue<K, V>>[size];
			}

			protected int GetArrayPosition(K key)
			{
				int position = key.GetHashCode() % size;
				return Math.Abs(position);
			}

			public V Find(K key)
			{
				int position = GetArrayPosition(key);
				LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
				foreach(KeyValue<K, V> item in linkedList)
				{
					if(item.Key.Equals(key))
					{
						return item.Value;
					}
				}

				return default(V);
			}

			/// <summary>
			/// Adds the specified key.
			/// </summary>
			/// <param name="key">The key.</param>
			/// <param name="value">The value.</param>
			/// <remarks></remarks>
			public void Add(K key, V value)
			{
				int position = GetArrayPosition(key);
				LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
				KeyValue<K, V> item = new KeyValue<K, V>()
				{
					Key = key,
					Value = value
				};
				linkedList.AddLast(item);
			}

			/// <summary>
			/// Removes the specified key.
			/// </summary>
			/// <param name="key">The key.</param>
			/// <remarks></remarks>
			public void Remove(K key)
			{
				int position = GetArrayPosition(key);
				LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
				bool itemFound = false;
				KeyValue<K, V> foundItem = default(KeyValue<K, V>);
				foreach(KeyValue<K, V> item in linkedList)
				{
					if(item.Key.Equals(key))
					{
						itemFound = true;
						foundItem = item;
					}
				}

				if(itemFound)
				{
					linkedList.Remove(foundItem);
				}
			}

			/// <summary>
			/// Gets the linked list.
			/// </summary>
			/// <param name="position">The position.</param>
			/// <returns></returns>
			/// <remarks></remarks>
			protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
			{
				LinkedList<KeyValue<K, V>> linkedList = items[position];
				if(linkedList == null)
				{
					linkedList = new LinkedList<KeyValue<K, V>>();
					items[position] = linkedList;
				}

				return linkedList;
			}
		}
	}
}
