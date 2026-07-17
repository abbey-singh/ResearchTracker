const API_BASE_URL = 'http://localhost:5274/api/ResearchProjects';

export async function getResearchProjects() {
    const response = await fetch(API_BASE_URL);

    if (!response.ok) {
        throw new Error(
            `Failed to load research projects. Status: ${response.status}`
        );
    }

    return response.json();
}

export async function createResearchProject(project) {
    const response = await fetch(API_BASE_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(project)
    });

    if (!response.ok) {
        throw new Error(
            `Failed to create research project. Status: ${response.status}`
        );
    }

    return response.json();
}

export async function deleteResearchProject(projectId) {
    const response = await fetch(`${API_BASE_URL}/${projectId}`, {
        method: "DELETE",
    });

    if (!response.ok) {
        throw new Error(
            `Failed to delete research project. Status: ${response.status}`
        );
    }
}

export async function updateResearchProject(id, project) {
    const response = await fetch(`${API_BASE_URL}/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(project),
    });

    if (!response.ok) {
        throw new Error(
            `Failed to update research project. Status: ${response.status}`
        );
    }

    return {
        id: id,
        ...project,
    };
}
