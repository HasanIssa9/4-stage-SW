graph = {
    'a': ['b', 'c','d'],
    'b': ['e','f'],
    'c': ['f', 'g'],
    'd': ['g','h'],
    'e': ['i','j'],
    'f': ['k'],
    'g':['l','n'],
    'h':['p','q'],
    'i':[],
    'j':[],
    'k':[],
    'l':[],
    'n':[],
    'p':[],
    'q':[]
}

visited = [] 
queue = []     

def bfs(visited, graph, node, goal):
    visited.append(node)
    queue.append(node)
    
    while queue:
        m = queue.pop(0)
        for neighbour in graph[m]:
            if neighbour not in visited:
                visited.append(neighbour)
                queue.append(neighbour)
                
            
    for i in visited:
        if i == goal:
            print(i)
            break
        else:
            print(i, end=" , ")

print("Following is the Breadth-First Search")
bfs(visited, graph, 'a', 'h')
