# Basic guidelines

## Unity

### Objects Naming conventions

#### Affixes (end of the name)

 - _Wrapper
   + An `Empty GameObject` (nothing more than "transform" basic component in the inspector), used to position/separate sub-game-objects
 - _Gfx
   + A GameObject used to display any kind of graphic (icons), can be `Sprite` or `Image` (or animation or video, etc...). Should never be coupled with other affixes and should never have any childrens in the hierarchy to avoid dependencies on such a "variable" GameObject
  - _Display
    + Used to display variables to the end-user, should always be a `Text GameObject`
  - _Btn
    + A `GameObject` that should do something when clicked/tapped by the user. Must come with childrens, childrens could be `_Gfx` or `_Display` or `Text GameObject` named `Text` (`Text` is used for never changing text)
  - _Window
    + A Special kind of `_Wrapper`, it's an `Empty GameObject` used to switch the User Interface currently displayed, should always ***cover the whole canvas***
  - _Tab
    + A Special kind of `_Wrapper`, it's an `Empty GameObject` used to switch the User Interface currently displayed, It ***never replace the whole canvas***, used to keep some common elements in the current _Window while switching other sub-elements
  - _Script
    + Special `Empty GameObject` that comes with a `Script` component, used to run some code
#### Special Affixes cases
  - _Window_Btn
    + A button used to trigger the display of a window must end with this suffix. The triggered `{name}_Window` element `{name}` must coincide with the _Window_Btn. ( E.G. Shop_Window will have a corresponding Shop_Window_Btn elements that triggers the display )
  - _Tab_Btn
    + A button used to trigger the display of a tab must end with this suffix. The triggered `{name}_Tab` element `{name}` must coincide with the _Tab_Btn. ( E.G. Electric_Tab will have a corresponding Electric_Tab_Btn elements that triggers the display )
