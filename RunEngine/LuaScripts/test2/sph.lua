function CreateSphere(map,M, N)

	local l = 1;

	local color = function(i, j)
	  local r = 127+math.sin(8*math.pi*((j-i*2)/M+0/91))*127;
	  local g = 127+math.sin(8*math.pi*((j-i)/M+1/90))*127;
	  local b = 127+math.sin(8*math.pi*((j-i/2)/M+2/92))*127;
	  --local a = (r+g+b)/3;
	  return Color(255,r,g,b);
	end;

	local Points = setmetatable({}, {__index = table});
	for i = 0, N do
	  for j = 1, M do
		Points:insert{
		  l*math.sin(math.pi*i/N)*math.cos(2*math.pi*j/M);
		  l*math.cos(math.pi*i/N);
		  l*math.sin(math.pi*i/N)*math.sin(2*math.pi*j/M);
		};
	  end;
	end;

	local vertex = setmetatable({}, {__index = table});
	for i = 1, N do
	  for j = 1, M do
		local p1 = (i-1)*M + j;
		local p2 = (i-1)*M + math.fmod(j,M)+1; 
		local p3 = i*M + j;
		local p4 = i*M + math.fmod(j,M)+1; 

		vertex:insert(Vertex(Points[p1][1],Points[p1][2],Points[p1][3],color(i,j),0,0));
		vertex:insert(Vertex(Points[p2][1],Points[p2][2],Points[p2][3],color(i,j+1),0,0));
		vertex:insert(Vertex(Points[p4][1],Points[p4][2],Points[p4][3],color(i+1,j+1),0,0));

		vertex:insert(Vertex(Points[p1][1],Points[p1][2],Points[p1][3],color(i,j),0,0));
		vertex:insert(Vertex(Points[p4][1],Points[p4][2],Points[p4][3],color(i+1,j+1),0,0));
		vertex:insert(Vertex(Points[p3][1],Points[p3][2],Points[p3][3],color(i+1,j),0,0));

	  end;
	end;

	local model = Render:NewModel3D();
	model:SetVertices(ToListVertex(vertex));
	
	local result = Object3D();
	result.Model = model;
	result.Actor = Physic:CreateSphere(math.random(),5,math.random(),1);
	
	return result;
end;