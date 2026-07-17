import { useEffect, useState } from "react";
import {
    createResearchProject,
    deleteResearchProject,
    updateResearchProject,
    getResearchProjects
} from "./services/researchProjectsApi";
import ProjectForm from "./components/ProjectForm";
import ProjectCard from "./components/ProjectCard";
import "./App.css";

function createEmptyForm() {
    return {
        title: "",
        researcherName: "",
        description: "",
        status: "Planning",
        startDate: new Date().toISOString().slice(0, 10),
    };
}

function App() {
    const [projects, setProjects] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState("");

    const [form, setForm] = useState(createEmptyForm);
    const [isSubmitting, setIsSubmitting] = useState(false);
    const [editingProjectId, setEditingProjectId] = useState(null);

    useEffect(() => {
        async function loadProjects() {
            try {
                setError("");

                const data = await getResearchProjects();
                setProjects(data);
            } catch (requestError) {
                setError(requestError.message);
            } finally {
                setIsLoading(false);
            }
        }

        loadProjects();
    }, []);

    function resetForm() {
        setForm(createEmptyForm());
        setEditingProjectId(null);
    }

    function handleInputChange(event) {
        const { name, value } = event.target;

        setForm((currentForm) => ({
            ...currentForm,
            [name]: value,
        }));
    }

    function handleEdit(project) {
        setEditingProjectId(project.id);

        setForm({
            title: project.title,
            researcherName: project.researcherName,
            description: project.description ?? "",
            status: project.status,
            startDate: project.startDate.slice(0, 10),
        });

        window.scrollTo({
            top: 0,
            behavior: "smooth",
        });
    }

    async function handleSubmit(event) {
        event.preventDefault();

        try {
            setError("");
            setIsSubmitting(true);

            const projectData = {
                ...form,
                startDate: new Date(form.startDate).toISOString(),
            };

            if (editingProjectId === null) {
                const newProject =
                    await createResearchProject(projectData);

                setProjects((currentProjects) => [
                    newProject,
                    ...currentProjects,
                ]);
            } else {
                const updatedProject =
                    await updateResearchProject(
                        editingProjectId,
                        projectData
                    );

                setProjects((currentProjects) =>
                    currentProjects.map((project) =>
                        project.id === editingProjectId
                            ? updatedProject
                            : project
                    )
                );
            }

            resetForm();
        } catch (requestError) {
            setError(requestError.message);
        } finally {
            setIsSubmitting(false);
        }
    }

    async function handleDelete(id) {
        const confirmed = window.confirm(
            "Are you sure you want to delete this project?"
        );

        if (!confirmed) {
            return;
        }

        try {
            setError("");

            await deleteResearchProject(id);

            setProjects((currentProjects) =>
                currentProjects.filter(
                    (project) => project.id !== id
                )
            );

            if (editingProjectId === id) {
                resetForm();
            }
        } catch (requestError) {
            setError(requestError.message);
        }
    }

    return (
        <main className="app">
            <header>
                <p className="eyebrow">
                    Research management
                </p>

                <h1>Research Tracker</h1>

                <p>
                    View and manage your research projects.
                </p>
            </header>

            <ProjectForm
                form={form}
                editingProjectId={editingProjectId}
                isSubmitting={isSubmitting}
                onInputChange={handleInputChange}
                onSubmit={handleSubmit}
                onCancel={resetForm}
            />

            {isLoading && (
                <p>Loading research projects...</p>
            )}

            {error && (
                <p className="error">{error}</p>
            )}

            {!isLoading &&
                !error &&
                projects.length === 0 && (
                    <p>No research projects found.</p>
                )}

            <section className="project-grid">
                {projects.map((project) => (
                    <ProjectCard
                        key={project.id}
                        project={project}
                        onEdit={handleEdit}
                        onDelete={handleDelete}
                    />
                ))}
            </section>
        </main>
    );
}

export default App;