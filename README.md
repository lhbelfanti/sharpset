<p align="center">
  <img src="media/sharpset.png" width="100" alt="Repository logo" />
</p>
<h3 align="center">Sharpset</h3>
<p align="center">Compiler for a Set Theory language, written in C#<p>
<p align="center">
    <img src="https://img.shields.io/github/repo-size/lhbelfanti/sharpset?label=Repo%20size" alt="Repo size" />
    <img src="https://img.shields.io/github/license/lhbelfanti/sharpset?label=License" alt="License" />
</p>

---
## Language definitions

**ANTLR4:** The grammar of this project is defined inside the [SetTheory.g4](./SetTheoryCompiler/SetTheory.g4)

* [Assignation & Variables](#variables)
* [show](#show)
* [set](#set)
* [max](#max)
* [min](#min)
* [avg](#avg)
* [int](#int)
* [uni](#uni)
* [ext](#ext)
* [len](#len)
* [add](#add)
* [del](#del)

### Assignation & Variables <a name="variables"></a>

Assigns a `set` to a `variable`, or a `variable` to a `variable`.

#### Example
- `a = [6,2]` → assign the set `[6,2]` to `a`
- `c = a` → assigns the value of the variable `a` to the variable `c` (`a` must be defined)

### show

Prints the value of a `variable`.

#### Example
- `a = [2]`<br>`show a` → prints `[2]`

### set

Creates a `set` based on three parameter:
 - `from`: The number where the set will start from
 - `to`: The number where the set will end - the `jump`
 - `jump`: Steps 

#### Example
- `b = set(10,50,2)` → create a `set` from 10 to 50 with a jump of 2: `[10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48]`

### max

Returns the `max` value from a `set`.

#### Example

- `a = [1,9]`<br>`max a` → returns `[9]`

### min

Returns the `min` value from a `set`.

#### Example

- `a = [1,9]`<br>`min a` → returns `[1]`

### avg
Returns the `avg` value from a `set`.

#### Example

- `a = [1,9]`<br>`avg a` → returns `[5]`

### int
Returns the `intersection` between two `sets`.

#### Example

- `a = [1,9]`<br> `b = [2,9]`<br>`int a,b` → returns `[9]`

### uni
Returns the `union` between two `sets`.

#### Example

- `a = [1,9]`<br> `b = [2,9]`<br>`uni a,b` → returns `[1,9,2]`

### ext
Removes a value from a `set`, based on the following parameters:
- `variable`: The variable containing the `set`
- `index`: The index number of the `set` that will be removed. Consider the `set` as an array where the index `0` is the first element

#### Example

- `a = [1,5,9]`<br>`ext a,0` → removes the first element from the `set`, so, the result will be the `set` without that element → `[5,9]`

### len
Returns the `length` (number of elements) of a `set`.

#### Example

- `a = [1,2,3]`<br> `len a` → returns `[3]`

### add
`Adds` an element to a `set`.

#### Example

- `a = [1,9]`<br> `add a,4` → returns `[1,9,4]`

### del
`Deletes` an element from a `set`.

#### Example

- `a = [1,9]`<br> `del a,9` → returns `[1]`

## Examples
Inside the SetTheoryCompiler Project, there is a [Program.cs](./SetTheoryCompiler/Program.cs) file that contains many examples of how the different operations work.

---
## License

[MIT](https://choosealicense.com/licenses/mit/)
