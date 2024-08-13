import { useEffect, useState } from "react";
import "./App.css";

function App() {
    const [courses, setCourses] = useState([]);

    const webapi = import.meta.env.VITE_WEBAPI;

    console.log("Webapi: ", webapi);

    const requestCourses = async () => {
        const courses = await fetch(`${webapi}/Courses`);
        console.log(courses);

        const coursesJson = await courses.json();
        console.log(coursesJson);

        setCourses(coursesJson);
    };

    useEffect(() => {
        requestCourses();
    }, []);

    return (
        <div className="App">
            <header className="App-header">
                <h1>Diskgolfbanor</h1>
                <table>
                    <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Hole count</th>
                    </tr>
                    </thead>
                    <tbody>
                    {(
                        courses ?? [
                            {
                                id: "No",
                                name: "No name",
                                holeCount: 0,
                            },
                        ]
                    ).map((w) => {
                        return (
                            <tr key={w.id}>
                                <td>{w.id}</td>
                                <td>{w.name}</td>
                                <td>{w.holeCount}</td>
                            </tr>
                        );
                    })}
                    </tbody>
                </table>
            </header>
        </div>
    );
}

export default App;