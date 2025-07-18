import React, { useEffect } from "react";

export const Exam: React.FC = () => {
    useEffect(() => {
        document.title = "Exam - My React Application";
    }, []);

    return (
        <div>
            <h2>Exam</h2>
            <div>
                <span> Here is where your work goes! </span>
            </div>
        </div>
    );
};
