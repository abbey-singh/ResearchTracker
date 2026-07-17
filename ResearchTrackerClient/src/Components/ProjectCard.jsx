function ProjectCard({ project, onEdit, onDelete }) {
    return (
        <article className="project-card">
            <div className="card-heading">
                <div>
                    <p className="status">{project.status}</p>
                    <h2>{project.title}</h2>
                </div>
            </div>

            <div className="card-actions">
                <button
                    className="edit-button"
                    type="button"
                    onClick={() => onEdit(project)}
                >
                    Edit
                </button>

                <button
                    className="delete-button"
                    type="button"
                    onClick={() => onDelete(project.id)}
                >
                    Delete
                </button>
            </div>

            <p>
                {project.description || "No description provided."}
            </p>

            <div className="project-details">
                <span>
                    Researcher: {project.researcherName}
                </span>

                <span>
                    Started:{" "}
                    {new Date(project.startDate).toLocaleDateString()}
                </span>
            </div>
        </article>
    );
}

export default ProjectCard;