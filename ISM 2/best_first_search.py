graph = {
    'a': {'z': 8, 'y': 9, 'x': 7},
    'z': {'m': 8, 'n': 6},
    'y': {'n': 7, 'p': 6},
    'x': {'p': 8, 'q': 7},
    'm': {'r': 4, 't': 3},
    'n': {'v': 6},
    'p': {'u': 9, 'h': 7},
    'q': {'k': 4, 'g': 2},
    'r': {},
    't': {},
    'v': {},
    'u': {},
    'h': {},
    'k': {},
    'g': {}
}

def best_first_search(graph, start, goal):
    visited = []
    queue = [[start]]
    if start == goal:
        return [start]
    
    while queue:
        queue.sort(key=lambda x: sum(graph[x[-1]].values()))
        path = queue.pop(0)
        current = path[-1]
        if current not in visited:
            for neighbor in graph[current]:
                new_path = list(path)
                new_path.append(neighbor)
                queue.append(new_path)
                if neighbor == goal:
                    return new_path
            visited.append(current)
    
    return None

start_node = 'a'
goal_node = 'k'

path = best_first_search(graph, start_node, goal_node)

if path is not None:
    print("Best First Search path:", ' -> '.join(path))
else:
    print("No path found from", start_node, "to", goal_node)
