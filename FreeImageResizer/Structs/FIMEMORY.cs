﻿using System;
using System.Runtime.InteropServices;

namespace FreeImageAPI
{
    /// <summary>
    /// The <b>FIMEMORY</b> structure is a handle to an opened memory stream.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FIMEMORY : IComparable, IComparable<FIMEMORY>, IEquatable<FIMEMORY>
    {
        private IntPtr data;

        /// <summary>
        /// A read-only field that represents a handle that has been initialized to zero.
        /// </summary>
        public static readonly FIMEMORY Zero;

        /// <summary>
        /// Tests whether two specified <see cref="FIMEMORY"/> structures are equivalent.
        /// </summary>
        /// <param name="left">The <see cref="FIMEMORY"/> that is to the left of the equality operator.</param>
        /// <param name="right">The <see cref="FIMEMORY"/> that is to the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if the two <see cref="FIMEMORY"/> structures are equal; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(FIMEMORY left, FIMEMORY right)
        {
            return (left.data == right.data);
        }

        /// <summary>
        /// Tests whether two specified <see cref="FIMEMORY"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="FIMEMORY"/> that is to the left of the inequality operator.</param>
        /// <param name="right">The <see cref="FIMEMORY"/> that is to the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if the two <see cref="FIMEMORY"/> structures are different; otherwise, <b>false</b>.
        /// </returns>
        public static bool operator !=(FIMEMORY left, FIMEMORY right)
        {
            return (left.data != right.data);
        }

        /// <summary>
        /// Gets whether the pointer is a null pointer or not.
        /// </summary>
        /// <value><b>true</b> if this <see cref="FIMEMORY"/> is a null pointer;
        /// otherwise, <b>false</b>.</value>		
        public bool IsNull
        {
            get
            {
                return (data == IntPtr.Zero);
            }
        }

        /// <summary>
        /// Sets the handle to <i>null</i>.
        /// </summary>
        public void SetNull()
        {
            data = IntPtr.Zero;
        }

        /// <summary>
        /// Converts the numeric value of the <see cref="FIMEMORY"/> object
        /// to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public override string ToString()
        {
            return data.ToString();
        }

        /// <summary>
        /// Returns a hash code for this <see cref="FIMEMORY"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies the hash code for this <see cref="FIMEMORY"/>.</returns>
        public override int GetHashCode()
        {
            return data.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="Object"/> is equal to the current <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare with the current <see cref="Object"/>.</param>
        /// <returns><b>true</b> if the specified <see cref="Object"/> is equal to the current <see cref="Object"/>; otherwise, <b>false</b>.</returns>
        public override bool Equals(object obj)
        {
            return ((obj is FIMEMORY) && (this == ((FIMEMORY)obj)));
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><b>true</b> if the current object is equal to the other parameter; otherwise, <b>false</b>.</returns>
        public bool Equals(FIMEMORY other)
        {
            return (this == other);
        }

        /// <summary>
        /// Compares this instance with a specified <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A 32-bit signed integer indicating the lexical relationship between the two comparands.</returns>
        /// <exception cref="ArgumentException"><paramref name="obj"/> is not a <see cref="FIMEMORY"/>.</exception>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is FIMEMORY))
            {
                throw new ArgumentException("obj");
            }
            return CompareTo((FIMEMORY)obj);
        }

        /// <summary>
        /// Compares this instance with a specified <see cref="FIMEMORY"/> object.
        /// </summary>
        /// <param name="other">A <see cref="FIMEMORY"/> to compare.</param>
        /// <returns>A signed number indicating the relative values of this instance
        /// and <paramref name="other"/>.</returns>
        public int CompareTo(FIMEMORY other)
        {
            return this.data.ToInt64().CompareTo(other.data.ToInt64());
        }
    }
}