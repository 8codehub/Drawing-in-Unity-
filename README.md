# How to Draw a Line with Touch Input in Unity 2D: A Beginner’s Guide

This guide walks you through the steps to create a 2D line that can be drawn using touch input in Unity. The line will be rendered using a Line Renderer component and will have an Edge Collider 2D component added to it for interaction with other objects in the game. Additionally, a script will be created to handle the drawing of the line based on touch input, with new line segments being added dynamically as the user moves their finger or mouse across the screen.

## Prerequisites
- Unity 2D
- Basic understanding of the Unity Editor and scripting in C#

## Steps

### Step 1: Create an Empty GameObject
1. Right-click in the Hierarchy window and select “Create Empty”.
2. Name the newly created empty game object as “Drawable”.

### Step 2: Add Line Renderer Component
1. Select the “Drawable” object in the Hierarchy window.
2. In the Inspector window, click “Add Component”.
3. Select “Line Renderer”.

### Step 3: Create a Material
1. Create a folder named “Materials” to store the material in the Assets panel.
2. Right-click in the Assets panel and select “Create” followed by “Material”.
3. Assign a material to the newly created material object.

### Step 4: Assign the Material to the Line Renderer
1. Select the “Drawable” object in the Hierarchy window.
2. Find the Line Renderer component in the Inspector panel.
3. In the “Materials” section, select the material you created from the Assets folder.

### Step 5: Move the Object to the Prefabs Folder
1. Move “Drawable” to the “Prefabs” folder in the Assets panel.
2. Delete “Drawable” from the Hierarchy window.

### Step 6: Add “EdgeCollider2D” to the “Drawable”
1. Select the “Drawable” prefab in the Assets panel.
2. In the Inspector window, click “Add Component”.
3. Select “Edge Collider 2D”.

### Step 7: Create the Script to Draw the Line
1. Create a “Scripts” folder in the Assets panel by right-clicking in the Assets panel and selecting “Create” followed by “Folder”.
2. Right-click in the “Scripts” folder and select “Create” followed by “C# Script”.
3. Give the script a descriptive name, such as “LineDrawer”.

## Step 8: 
Open the script by double-clicking it in the panel and replace its contents with the provided code.

## Step 9: Adding the Script to the DrawableControler GameObject.

In this step, you’ll create a new empty object in the hierarchy, name it “DrawableControler”, and attach the script “LineDrawer” to it.

1. Right-click in the hierarchy and select “Create Empty”.
2. Name the newly created object “DrawableControler”.
3. Drag the script “LineDrawer” from the Assets/Scripts panel and drop it onto the “DrawableControler” object in the hierarchy panel.
4. The “LineDrawer” script is now attached to the “DrawableControler” GameObject.

## Step 10: Use the Drawable object from the prefab

We have a “linePrefab” GameObject inside “LineDrawer” C# code, we need to initialize it.

1. Click on “Drawable Controller” so you can see attached LineDrawer.
2. Open the “Prefabs” folder and move the “Drawable” object to the “linePrefab” variable of the “LineDrawer” script.

## Final Step: 
You’re ready to run the game to test your line drawing functionality.
