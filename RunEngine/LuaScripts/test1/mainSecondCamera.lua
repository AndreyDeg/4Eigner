dofile 'LuaScripts\\test1\\main.lua';

local camera2 = Render:NewCamera();
camera2.Map = World:GetMap(0);
camera2.BackColor = Color(255,0,0,0);
camera2.ViewPort = Viewport(
	Window.iWidth/2, --X
	Window.iHeight/2, --Y
	Window.iWidth/2, --Width
	Window.iHeight/2, --Height
	0, --MinZ
	1 --MaxZ
);