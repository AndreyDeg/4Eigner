local Vertexes = {
	Vertex(0,-500,  500, Color(255,255,255,255),    0,   0),
	Vertex(0, 500,  500, Color(255,255,255,255),  100,   0),
	Vertex(0,-500, -500, Color(255,255,255,255),    0, 100),
	Vertex(0, 500, -500, Color(255,255,255,255),  100, 100),
	Vertex(0,-500, -500, Color(255,255,255,255),    0, 100),
	Vertex(0, 500,  500, Color(255,255,255,255),  100,   0),
};

CreatePlane = function(map, texture)

	local result = Object3D();
	result.Actor = Physic:CreateGroundPlane();
	result.Model = Render:NewModel3D();
	result.Model:SetVertices(ToListVertex(Vertexes));
	result.Model:SetTexture(Render:LoadTexture(texture));

	map:AddObject(result);

	return result;
end;