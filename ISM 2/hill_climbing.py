import random

graph = {
    'a': [('b', 5), ('c', 4), ('d', 8)],
    'b': [('f', 5)],
    'c': [('f', 5)],
    'd': [('f', 5)],
    'f': [('n', 8), ("g", 3)],
    'g': [],
    'n': [('m', 7)],
    'm': []
}

def heuristic(node):
    distances = {
        'a': 6,
        'b': 4,
        'c': 4,
        'd': 6,
        'f': 3,
        'g': 0,
        'n': 1,
        'm': 0
    }
    return distances[node]

def stochastic_hill_climbing(start, goal):
    current_node = start
    path = [current_node]
    while current_node != goal:
        neighbors = graph[current_node]
        best_neighbors = []
        best_score = float('inf')
        for neighbor, _ in neighbors:
            score = heuristic(neighbor)
            if score < best_score:
                best_neighbors = [neighbor]
                best_score = score
            elif score == best_score:
                best_neighbors.append(neighbor)
        if best_score >= heuristic(current_node):
            print("Local maxima or plateau reached, exiting...")
            break
        current_node = random.choice(best_neighbors)
        path.append(current_node)
    if current_node == goal:
        print("Goal reached!")
        return path
    else:
        print("Goal not found!")
        return None

start_node = 'a'
goal_node = 'g'
path = stochastic_hill_climbing(start_node, goal_node)
if path is not None:
    print("Path found:", path)
else:
    print("Path not found!")
