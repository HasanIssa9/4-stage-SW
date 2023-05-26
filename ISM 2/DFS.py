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

def dfs(graph, start, end, visited=None):
    if visited is None:
        visited = []
    visited.append(start)
    if start == end:
        return visited
    for neighbor in graph[start]:
        if neighbor not in visited:
            path = dfs(graph, neighbor, end, visited)
            if path is not None:
                return path
    return None


print( dfs(graph, 'a', 'k'))