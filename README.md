# PietSharp

[Official Piet language spec](https://www.dangermouse.net/esoteric/piet.html)

## Execution Concepts

Piet Image => Compilation => Execution

### Piet Image

An image file. Supported file types TBD.

Shall include a custom file type with a reduced size. Only need 5 bits: 1 for each color (6 hues \* 3 lightnesses + white + black + EOL = 21, 2\^5-1=31).

### Compilation

This arranges a graph of ColorBlocks for later execution.

Of particular issue are WHITE codels. Ideally, these would be a no-op and could be ignored.
Unfortunately, their behavior (in regards to the DirectionPointer/CodelChooser)
breaks convention and depends on actual positioning rather than simple graph neighbors.

This issue is TBD for this proposed implemention.

### Execution

Once the ColorBlock graph is constructed in memory, execution should be as easy as comparing the "current" ColorBlock to the next.
