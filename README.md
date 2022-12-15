# CS345-Fuzzy-Logic-Activity

This is my modified version of a ***Washing Machine Wash Time Controller*** using Fuzzy Logic.

The base code is from my professor **Sir Chris Jordan Aliac** and it uses `DOTFUZZY` library.

## Linguistic Variables
**For Inputs**:

`Type of Dirt`:
{
  Non-Greasy,
  Medium,
  Greasy
 }

`Quality of Dirt`:
{
  Large,
  Medium,
  Small
}

**For Output**:

`Wash Time`:
{
  Short,
  Very Short,
  Medium,
  Long,
  Very Long
}

## Fuzzy Membership Functions
`Type of Dirt`

![image](https://user-images.githubusercontent.com/111746868/207886499-67322f85-f4f3-447c-b4ce-265896583097.png)

`Quality of Dirt`

![image](https://user-images.githubusercontent.com/111746868/207886602-1ff278c6-86dc-4e35-aaa1-3273f91db1d9.png)

## Rules
- IF *quality of dirt* is `Small` AND *Type of dirt* is `Greasy`, THEN *Wash Time* is `Long`.
- IF *quality of dirt* is `Medium` AND *Type of dirt* is `Greasy`, THEN *Wash Time* is `Long`.
- IF *quality of dirt* is `Large` AND *Type of dirt* is `Greasy`, THEN *Wash Time* is `Very Long`.
- IF *quality of dirt* is `Small` AND *Type of dirt* is `Medium`, THEN *Wash Time* is `Medium`.
- IF *quality of dirt* is `Medium` AND *Type of dirt* is `Medium`, THEN *Wash Time* is `Medium`.
- IF *quality of dirt* is `Large` AND *Type of dirt* is `Medium`, THEN *Wash Time* is `Medium`.
- IF *quality of dirt* is `Small` AND *Type of dirt* is `Non-Greasy`, THEN *Wash Time* is `Very Short`.
- IF *quality of dirt* is `Medium` AND *Type of dirt* is `Non-Greasy`, THEN *Wash Time* is `Short`.
- IF *quality of dirt* is `Large` AND *Type of dirt* is `Non-Greasy`, THEN *Wash Time* is `Short`.
