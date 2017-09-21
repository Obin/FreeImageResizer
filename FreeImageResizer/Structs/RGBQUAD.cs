using System;
using System.Runtime.InteropServices;

namespace FreeImageAPI
{
	[StructLayout(LayoutKind.Explicit)]
	public struct RGBQUAD : IComparable, IEquatable<RGBQUAD>
	{
		/// <summary>
		/// The blue color component.
		/// </summary>
		[FieldOffset(0)]
		public byte rgbBlue;

		/// <summary>
		/// The green color component.
		/// </summary>
		[FieldOffset(1)]
		public byte rgbGreen;

		/// <summary>
		/// The red color component.
		/// </summary>
		[FieldOffset(2)]
		public byte rgbRed;

		/// <summary>
		/// The alpha color component.
		/// </summary>
		[FieldOffset(3)]
		public byte rgbReserved;

		/// <summary>
		/// The color's value.
		/// </summary>
		[FieldOffset(0)]
		public uint uintValue;

		/// <summary>
		/// Tests whether two specified <see cref="RGBQUAD"/> structures are equivalent.
		/// </summary>
		/// <param name="left">The <see cref="RGBQUAD"/> that is to the left of the equality operator.</param>
		/// <param name="right">The <see cref="RGBQUAD"/> that is to the right of the equality operator.</param>
		/// <returns>
		/// <b>true</b> if the two <see cref="RGBQUAD"/> structures are equal; otherwise, <b>false</b>.
		/// </returns>
		public static bool operator ==(RGBQUAD left, RGBQUAD right)
		{
			return (left.uintValue == right.uintValue);
		}

		/// <summary>
		/// Tests whether two specified <see cref="RGBQUAD"/> structures are different.
		/// </summary>
		/// <param name="left">The <see cref="RGBQUAD"/> that is to the left of the inequality operator.</param>
		/// <param name="right">The <see cref="RGBQUAD"/> that is to the right of the inequality operator.</param>
		/// <returns>
		/// <b>true</b> if the two <see cref="RGBQUAD"/> structures are different; otherwise, <b>false</b>.
		/// </returns>
		public static bool operator !=(RGBQUAD left, RGBQUAD right)
		{
			return (left.uintValue != right.uintValue);
		}

		/// <summary>
		/// Converts the value of an <see cref="UInt32"/> structure to a <see cref="RGBQUAD"/> structure.
		/// </summary>
		/// <param name="value">An <see cref="UInt32"/> structure.</param>
		/// <returns>A new instance of <see cref="RGBQUAD"/> initialized to <paramref name="value"/>.</returns>
		public static implicit operator RGBQUAD(uint value)
		{
			RGBQUAD result = new RGBQUAD();
			result.uintValue = value;
			return result;
		}

		/// <summary>
		/// Converts the value of a <see cref="RGBQUAD"/> structure to an <see cref="UInt32"/> structure.
		/// </summary>
		/// <param name="value">A <see cref="RGBQUAD"/> structure.</param>
		/// <returns>A new instance of <see cref="RGBQUAD"/> initialized to <paramref name="value"/>.</returns>
		public static implicit operator uint(RGBQUAD value)
		{
			return value.uintValue;
		}

		/// <summary>
		/// Compares this instance with a specified <see cref="Object"/>.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>A 32-bit signed integer indicating the lexical relationship between the two comparands.</returns>
		/// <exception cref="ArgumentException"><paramref name="obj"/> is not a <see cref="RGBQUAD"/>.</exception>
		public int CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			if (!(obj is RGBQUAD))
			{
				throw new ArgumentException("obj");
			}
			return CompareTo((RGBQUAD)obj);
		}

		/// <summary>
		/// Tests whether the specified object is a <see cref="RGBQUAD"/> structure
		/// and is equivalent to this <see cref="RGBQUAD"/> structure.
		/// </summary>
		/// <param name="obj">The object to test.</param>
		/// <returns><b>true</b> if <paramref name="obj"/> is a <see cref="RGBQUAD"/> structure
		/// equivalent to this <see cref="RGBQUAD"/> structure; otherwise, <b>false</b>.</returns>
		public override bool Equals(object obj)
		{
			return ((obj is RGBQUAD) && (this == ((RGBQUAD)obj)));
		}

		/// <summary>
		/// Tests whether the specified <see cref="RGBQUAD"/> structure is equivalent to this <see cref="RGBQUAD"/> structure.
		/// </summary>
		/// <param name="other">A <see cref="RGBQUAD"/> structure to compare to this instance.</param>
		/// <returns><b>true</b> if <paramref name="obj"/> is a <see cref="RGBQUAD"/> structure
		/// equivalent to this <see cref="RGBQUAD"/> structure; otherwise, <b>false</b>.</returns>
		public bool Equals(RGBQUAD other)
		{
			return (this == other);
		}

		/// <summary>
		/// Returns a hash code for this <see cref="RGBQUAD"/> structure.
		/// </summary>
		/// <returns>An integer value that specifies the hash code for this <see cref="RGBQUAD"/>.</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}