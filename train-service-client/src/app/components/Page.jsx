import TextBlock from "./TextBlock.jsx";
import TestBlock from "./TestBlock.jsx";

const Page = ({ texts, tests }) => {
    const items = [
        ...texts.map(text => ({ type: 'text', number: text.number, data: text })),
        ...tests.map(test => ({ type: 'test', number: test.number, data: test }))
    ].sort((a, b) => a.number - b.number);

    return (
        <div className="w-100">
            {items.map((item, index) => {
                if (item.type === 'text') {
                    return <TextBlock key={`text-${index}`} text={item.data.data} />;
                } else {
                    return <TestBlock key={`test-${index}`} test={item.data} />;
                }
            })}
        </div>
    );
};
export default Page;